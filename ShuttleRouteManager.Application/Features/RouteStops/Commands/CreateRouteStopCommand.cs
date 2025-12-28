using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.RouteStops.Commands;

public class CreateRouteStopCommand : IRequest<BaseResult<object>>
{
    public int SequenceNumber { get; set; }
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Address { get; set; } = default!;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public TimeSpan EstimatedArrivalTimeMorning { get; set; }
    public TimeSpan EstimatedArrivalTimeEvening { get; set; }
    public Guid RouteId { get; set; }
}
