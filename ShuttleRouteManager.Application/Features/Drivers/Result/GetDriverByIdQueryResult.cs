using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Application.Features.Routes.Result;
using ShuttleRouteManager.Domain.Absractions;

namespace ShuttleRouteManager.Application.Features.Drivers.Result;

public class GetDriverByIdQueryResult : EntityDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public DateTimeOffset JobStartDate { get; set; }
    public Guid CompanyId { get; set; }

  
    public CompanySummaryDto? Company { get; set; }
    public List<RouteSummaryDto> Routes { get; set; } = new();
}
