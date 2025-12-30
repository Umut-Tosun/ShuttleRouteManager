using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.Buses.Commands;
using ShuttleRouteManager.Application.Features.Buses.Queries;

namespace ShuttleRouteManager.Application.Features.Buses.Endpoints;

public static class BusEndpoints
{
    public static void RegisterBusEndpoints(this IEndpointRouteBuilder app)
    {
        var buses = app.MapGroup("/buses").WithTags("Buses").RequireAuthorization();

        buses.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetBusesQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        buses.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetBusByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        buses.MapGet("/company/{companyId:guid}", async (IMediator mediator, Guid companyId) =>
        {
            var response = await mediator.Send(new GetBusesByCompanyIdQuery(companyId));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        buses.MapPost(string.Empty, async (IMediator mediator, CreateBusCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        buses.MapPut(string.Empty, async (IMediator mediator, UpdateBusCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        buses.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveBusCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}
