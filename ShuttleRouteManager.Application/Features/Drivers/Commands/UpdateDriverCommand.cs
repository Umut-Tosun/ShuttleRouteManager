using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Drivers.Commands;

public class UpdateDriverCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public DateTimeOffset JobStartDate { get; set; }
    public Guid CompanyId { get; set; }
}
