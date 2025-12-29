using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Application.Features.Routes.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.Buses.Result;

public class GetBusesQueryResult
{
    public Guid Id { get; set; }
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public int Capacity { get; set; }
    public decimal Km { get; set; }
    public Guid CompanyId { get; set; }
    public Guid? DefaultDriverId { get; set; }
    public CompanySummaryDto Company { get; set; } = default!;
    public DriverSummaryDto? DefaultDriver { get; set; }
    public List<RouteSummaryDto> Routes { get; set; } = new();
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset LastUpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
