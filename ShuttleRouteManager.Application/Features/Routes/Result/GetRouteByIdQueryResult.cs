using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.Routes.Result;

public class GetRouteByIdQueryResult : EntityDto
{
    public string Name { get; set; } = default!;
    public string StartPoint { get; set; } = default!;
    public string EndPoint { get; set; } = default!;
    public TimeSpan MorningStartTime { get; set; }
    public TimeSpan EveningStartTime { get; set; }
    public Guid BusId { get; set; }
    public Guid DriverId { get; set; }

    
    public BusForRouteSummaryDto? Bus { get; set; }
    public DriverForRouteSummaryDto? Driver { get; set; }
    public List<RouteStopForRouteDto> RouteStops { get; set; } = new();

}
