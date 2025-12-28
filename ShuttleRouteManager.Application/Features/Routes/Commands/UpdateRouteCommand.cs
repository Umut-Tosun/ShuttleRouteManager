using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Routes.Commands;

public class UpdateRouteCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string StartPoint { get; set; } = default!;
    public string EndPoint { get; set; } = default!;
    public TimeSpan MorningStartTime { get; set; }
    public TimeSpan EveningStartTime { get; set; }
    public Guid BusId { get; set; }
    public Guid DriverId { get; set; }
}
