using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.TripAppUsers.Queries;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Handlers;

public class GetTripAppUsersQueryHandler(
    IRepository<TripAppUser> repository,
    IMapper mapper) : IRequestHandler<GetTripAppUsersQuery, BaseResult<List<GetTripAppUsersQueryResult>>>
{
    public async Task<BaseResult<List<GetTripAppUsersQueryResult>>> Handle(GetTripAppUsersQuery request, CancellationToken cancellationToken)
    {
        var tripAppUsers = await repository.GetAllAsync();
        var result = mapper.Map<List<GetTripAppUsersQueryResult>>(tripAppUsers);
        return BaseResult<List<GetTripAppUsersQueryResult>>.Success(result);
    }
}



