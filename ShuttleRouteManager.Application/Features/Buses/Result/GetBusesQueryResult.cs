using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Application.Features.Routes.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.Buses.Result;

public class GetBusesQueryResult : EntityDto
{
    public string PlateNo { get; set; } = default!;
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public int Capacity { get; set; }
    public decimal Km { get; set; }
    public Guid CompanyId { get; set; }

    // SİL: Company ve Routes
}
