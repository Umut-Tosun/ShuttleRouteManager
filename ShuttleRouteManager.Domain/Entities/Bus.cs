using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Domain.Entities;

public sealed class Bus : Entity
{
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; } = default!;
    public int Capacity { get; set; } 
    public decimal Km { get; set; }
}
