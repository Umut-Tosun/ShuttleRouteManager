using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public sealed class Route : Entity
{
    public string Name { get; set; } = default!;
    public string StartPoint { get; set; } = default!;
    public string EndPoint { get; set; } = default!;
    public TimeSpan MorningStartTime { get; set; }
    public TimeSpan EveningStartTime { get; set; }
}
