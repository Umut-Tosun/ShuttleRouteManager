namespace ShuttleRouteManager.Application.Features.Routes.Result;

public class RouteStopForRouteDto
{
    public Guid Id { get; set; }
    public int SequenceNumber { get; set; }
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public TimeSpan EstimatedArrivalTimeMorning { get; set; }
    public TimeSpan EstimatedArrivalTimeEvening { get; set; }
}