using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.AppUsers.Commands;
using ShuttleRouteManager.Application.Features.AppUsers.Queries;

namespace ShuttleRouteManager.Application.Features.AppUsers.Endpoints;

public static class AppUserEndpoints
{
    public static void RegisterAppUserEndpoints(this IEndpointRouteBuilder app)
    {
        var users = app.MapGroup("/users").WithTags("Users");

        users.MapPost("/register", async (IMediator mediator, RegisterUserCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        }).AllowAnonymous();

        users.MapPost("/login", async (IMediator mediator, LoginQuery query) =>
        {
            var response = await mediator.Send(query);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        }).AllowAnonymous();

        users.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetUsersQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        users.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetUserByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        users.MapPut(string.Empty, async (IMediator mediator, UpdateUserCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}
