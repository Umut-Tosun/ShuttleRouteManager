using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Queries;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class GetRoutesByBusIdQueryHandler(
    IRepository<Domain.Entities.Route> repository,
    IMapper mapper) : IRequestHandler<GetRoutesByBusIdQuery, BaseResult<List<GetRoutesQueryResult>>>
{
    public async Task<BaseResult<List<GetRoutesQueryResult>>> Handle(GetRoutesByBusIdQuery request, CancellationToken cancellationToken)
    {
        var routes = await repository.GetAllAsync(r => r.BusId == request.BusId);
        var result = mapper.Map<List<GetRoutesQueryResult>>(routes);
        return BaseResult<List<GetRoutesQueryResult>>.Success(result);
    }
}



