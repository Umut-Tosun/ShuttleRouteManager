using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.RouteStops.Commands;
using ShuttleRouteManager.Application.Features.RouteStops.Queries;

namespace ShuttleRouteManager.Application.Features.RouteStops.Endpoints;

public static class RouteStopEndpoints
{
    public static void RegisterRouteStopEndpoints(this IEndpointRouteBuilder app)
    {
        var routeStops = app.MapGroup("/routestops").WithTags("RouteStops").RequireAuthorization();

        routeStops.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetRouteStopsQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routeStops.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetRouteStopByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        routeStops.MapGet("/route/{routeId:guid}", async (IMediator mediator, Guid routeId) =>
        {
            var response = await mediator.Send(new GetRouteStopsByRouteIdQuery(routeId));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routeStops.MapPost(string.Empty, async (IMediator mediator, CreateRouteStopCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routeStops.MapPut(string.Empty, async (IMediator mediator, UpdateRouteStopCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        routeStops.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveRouteStopCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}
