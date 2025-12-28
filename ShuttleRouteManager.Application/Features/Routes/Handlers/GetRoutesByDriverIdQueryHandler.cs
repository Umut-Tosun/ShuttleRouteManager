using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Queries;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class GetRoutesByDriverIdQueryHandler(
    IRepository<Domain.Entities.Route> repository,
    IMapper mapper) : IRequestHandler<GetRoutesByDriverIdQuery, BaseResult<List<GetRoutesQueryResult>>>
{
    public async Task<BaseResult<List<GetRoutesQueryResult>>> Handle(GetRoutesByDriverIdQuery request, CancellationToken cancellationToken)
    {
        var routes = await repository.GetAllAsync(r => r.DriverId == request.DriverId);
        var result = mapper.Map<List<GetRoutesQueryResult>>(routes);
        return BaseResult<List<GetRoutesQueryResult>>.Success(result);
    }
}




