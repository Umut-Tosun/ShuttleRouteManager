using ShuttleRouteManager.Application.Features.AppUsers.Endpoints;
using ShuttleRouteManager.Application.Features.Buses.Endpoints;
using ShuttleRouteManager.Application.Features.Companies.Endpoints;
using ShuttleRouteManager.Application.Features.Drivers.Endpoints;
using ShuttleRouteManager.Application.Features.RouteStops.Endpoints;
using ShuttleRouteManager.Application.Features.TripAppUsers.Endpoints;

namespace ShuttleRouteManager.API.EndpointsRegistration;

public static class EndpointRegistrations
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        app.RegisterCompanyEndpoints();
        app.RegisterDriverEndpoints();
        app.RegisterBusEndpoints();
        app.RegisterRouteStopEndpoints();
        app.RegisterRouteStopEndpoints();
        app.RegisterTripAppUserEndpoints();
        app.RegisterAppUserEndpoints();
    }
}
