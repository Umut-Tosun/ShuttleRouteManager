using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Queries;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class GetRoutesQueryHandler(
    IRepository<Domain.Entities.Route> repository,
    IMapper mapper) : IRequestHandler<GetRoutesQuery, BaseResult<List<GetRoutesQueryResult>>>
{
    public async Task<BaseResult<List<GetRoutesQueryResult>>> Handle(GetRoutesQuery request, CancellationToken cancellationToken)
    {
        var routes = await repository.GetAllAsync();
        var result = mapper.Map<List<GetRoutesQueryResult>>(routes);
        return BaseResult<List<GetRoutesQueryResult>>.Success(result);
    }
}