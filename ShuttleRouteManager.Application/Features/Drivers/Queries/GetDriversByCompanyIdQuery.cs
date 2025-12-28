using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Drivers.Result;

namespace ShuttleRouteManager.Application.Features.Drivers.Queries;

public record GetDriversByCompanyIdQuery(Guid CompanyId) : IRequest<BaseResult<List<GetDriversQueryResult>>>;