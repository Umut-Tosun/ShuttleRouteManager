using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Features.Drivers.Commands;
using ShuttleRouteManager.Application.Features.Drivers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuttleRouteManager.Application.Features.Drivers.Endpoints
{
    public static class DriverEndpoints
    {
        public static void RegisterDriverEndpoints(this IEndpointRouteBuilder app)
        {
            var drivers = app.MapGroup("/drivers").WithTags("Drivers");

            drivers.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetDriversQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            drivers.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var response = await mediator.Send(new GetDriverByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.NotFound(response);
            });

            drivers.MapGet("/company/{companyId:guid}", async (IMediator mediator, Guid companyId) =>
            {
                var response = await mediator.Send(new GetDriversByCompanyIdQuery(companyId));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            drivers.MapPost(string.Empty, async (IMediator mediator, CreateDriverCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            drivers.MapPut(string.Empty, async (IMediator mediator, UpdateDriverCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            drivers.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
            {
                var response = await mediator.Send(new RemoveDriverCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
