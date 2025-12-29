using ShuttleRouteManager.Application.Features.Companies.Result;

namespace ShuttleRouteManager.Application.Features.Drivers.Result;

public class RouteSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string StartPoint { get; set; } = default!;
    public string EndPoint { get; set; } = default!;
    public DriverSummaryDto? Driver { get; set; }
}