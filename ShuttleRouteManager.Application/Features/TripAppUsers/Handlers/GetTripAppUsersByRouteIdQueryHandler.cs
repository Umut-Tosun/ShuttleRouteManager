using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.TripAppUsers.Queries;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Handlers;

public class GetTripAppUsersByRouteIdQueryHandler(
    IRepository<TripAppUser> repository,
    IMapper mapper) : IRequestHandler<GetTripAppUsersByRouteIdQuery, BaseResult<List<GetTripAppUsersQueryResult>>>
{
    public async Task<BaseResult<List<GetTripAppUsersQueryResult>>> Handle(GetTripAppUsersByRouteIdQuery request, CancellationToken cancellationToken)
    {
        var tripAppUsers = await repository.GetAllAsync(t => t.RouteId == request.RouteId);
        var result = mapper.Map<List<GetTripAppUsersQueryResult>>(tripAppUsers);
        return BaseResult<List<GetTripAppUsersQueryResult>>.Success(result);
    }
}