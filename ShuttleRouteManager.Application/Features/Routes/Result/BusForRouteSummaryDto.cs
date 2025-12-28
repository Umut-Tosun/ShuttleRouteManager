namespace ShuttleRouteManager.Application.Features.Routes.Result;

public class BusForRouteSummaryDto
{
    public Guid Id { get; set; }
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
}
