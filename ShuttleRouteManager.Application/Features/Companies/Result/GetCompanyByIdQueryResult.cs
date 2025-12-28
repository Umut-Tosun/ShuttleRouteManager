using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.Companies.Result;

public class GetCompanyByIdQueryResult : EntityDto
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ResponsiblePerson { get; set; } = default!;
    public string ResponsiblePersonPhoneNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public DateTimeOffset ContractDate { get; set; }
    public DateTimeOffset ContractEndDate { get; set; }

  
    public List<DriverSummaryDto> Drivers { get; set; } = new();
    public List<BusSummaryDto> Buses { get; set; } = new();
}
