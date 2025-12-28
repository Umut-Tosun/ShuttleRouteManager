using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;
using ShuttleRouteManager.Application.Features.TripAppUsers.Queries;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Endpoints;

public static class TripAppUserEndpoints
{
    public static void RegisterTripAppUserEndpoints(this IEndpointRouteBuilder app)
    {
        var tripAppUsers = app.MapGroup("/tripappusers").WithTags("TripAppUsers");

        tripAppUsers.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetTripAppUsersQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        tripAppUsers.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetTripAppUserByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        tripAppUsers.MapGet("/user/{userId:guid}", async (IMediator mediator, Guid userId) =>
        {
            var response = await mediator.Send(new GetTripAppUsersByUserIdQuery(userId));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        tripAppUsers.MapGet("/route/{routeId:guid}", async (IMediator mediator, Guid routeId) =>
        {
            var response = await mediator.Send(new GetTripAppUsersByRouteIdQuery(routeId));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        tripAppUsers.MapPost(string.Empty, async (IMediator mediator, CreateTripAppUserCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        tripAppUsers.MapPut(string.Empty, async (IMediator mediator, UpdateTripAppUserCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        tripAppUsers.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveTripAppUserCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}
