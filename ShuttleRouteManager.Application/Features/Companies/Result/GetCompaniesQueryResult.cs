using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.Companies.Result;

public class GetCompaniesQueryResult : Entity
{
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ResponsiblePerson { get; set; } = default!;
    public string ResponsiblePersonPhoneNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public DateTimeOffset ContractDate { get; set; }
    public DateTimeOffset ContractEndDate { get; set; }
    public ICollection<GetDriversQueryResult>? Drivers { get; set; }
    public ICollection<GetBusesQueryResult>? Buses { get; set; }
}
