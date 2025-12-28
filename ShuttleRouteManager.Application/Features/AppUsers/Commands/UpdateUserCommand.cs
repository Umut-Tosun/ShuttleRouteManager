using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.AppUsers.Commands;

public class UpdateUserCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string HomeCity { get; set; } = default!;
    public string HomeDistrict { get; set; } = default!;
    public string HomeAddress { get; set; } = default!;
    public decimal HomeLatitude { get; set; }
    public decimal HomeLongitude { get; set; }
    public Guid? DefaultRouteStopId { get; set; }
}
