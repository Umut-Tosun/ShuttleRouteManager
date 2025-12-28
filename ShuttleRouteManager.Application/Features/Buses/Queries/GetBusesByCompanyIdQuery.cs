using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Buses.Result;

namespace ShuttleRouteManager.Application.Features.Buses.Queries;

public record GetBusesByCompanyIdQuery(Guid CompanyId) : IRequest<BaseResult<List<GetBusesQueryResult>>>;
