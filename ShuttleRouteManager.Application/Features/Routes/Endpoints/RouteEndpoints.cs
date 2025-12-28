using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.Routes.Commands;
using ShuttleRouteManager.Application.Features.Routes.Queries;

namespace ShuttleRouteManager.Application.Features.Routes.Endpoints;

public static class RouteEndpoints
{
    public static void RegisterRouteEndpoints(this IEndpointRouteBuilder app)
    {
        var routes = app.MapGroup("/routes").WithTags("Routes");

        routes.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetRoutesQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routes.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetRouteByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        routes.MapGet("/driver/{driverId:guid}", async (IMediator mediator, Guid driverId) =>
        {
            var response = await mediator.Send(new GetRoutesByDriverIdQuery(driverId));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routes.MapGet("/bus/{busId:guid}", async (IMediator mediator, Guid busId) =>
        {
            var response = await mediator.Send(new GetRoutesByBusIdQuery(busId));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routes.MapPost(string.Empty, async (IMediator mediator, CreateRouteCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routes.MapPut(string.Empty, async (IMediator mediator, UpdateRouteCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routes.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveRouteCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}
