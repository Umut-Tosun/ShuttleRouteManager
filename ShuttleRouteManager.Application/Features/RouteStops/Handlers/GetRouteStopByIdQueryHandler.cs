using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.RouteStops.Queries;
using ShuttleRouteManager.Application.Features.RouteStops.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.RouteStops.Handlers;

public class GetRouteStopByIdQueryHandler(
    IRepository<RouteStop> repository,
    IMapper mapper) : IRequestHandler<GetRouteStopByIdQuery, BaseResult<GetRouteStopByIdQueryResult>>
{
    public async Task<BaseResult<GetRouteStopByIdQueryResult>> Handle(GetRouteStopByIdQuery request, CancellationToken cancellationToken)
    {
        var routeStop = await repository.GetByIdAsync(request.Id);
        if (routeStop == null)
        {
            return BaseResult<GetRouteStopByIdQueryResult>.NotFound("Durak bulunamadı.");
        }

        var result = mapper.Map<GetRouteStopByIdQueryResult>(routeStop);
        return BaseResult<GetRouteStopByIdQueryResult>.Success(result);
    }
}