namespace ShuttleRouteManager.Application.Features.Companies.Result;

public class BusSummaryDto
{
    public Guid Id { get; set; }
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public int Capacity { get; set; }
}