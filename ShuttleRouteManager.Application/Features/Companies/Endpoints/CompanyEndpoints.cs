using MediatR;
using ShuttleRouteManager.Application.Features.Companies.Commands;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ShuttleRouteManager.Application.Features.Companies.Queries;
namespace ShuttleRouteManager.Application.Features.Companies.Endpoints;

public static class CompanyEndpoints
{
    public static void RegisterCompanyEndpoints(this IEndpointRouteBuilder app)
    {
        var companies = app.MapGroup("/companies").WithTags("Companies").RequireAuthorization();

        companies.MapGet(string.Empty, async (IMediator mediator) =>
        {
            var response = await mediator.Send(new GetCompaniesQuery());
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        companies.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new GetCompanyByIdQuery(id));
            return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
        });

        companies.MapPost(string.Empty, async (IMediator mediator, CreateCompanyCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        companies.MapPut(string.Empty, async (IMediator mediator, UpdateCompanyCommand command) =>
        {
            var response = await mediator.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        companies.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var response = await mediator.Send(new RemoveCompanyCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });
    }
}
