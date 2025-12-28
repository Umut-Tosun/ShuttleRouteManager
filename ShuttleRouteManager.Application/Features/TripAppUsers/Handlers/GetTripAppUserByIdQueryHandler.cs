using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.TripAppUsers.Queries;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Handlers;

public class GetTripAppUserByIdQueryHandler(
    IRepository<TripAppUser> repository,
    IMapper mapper) : IRequestHandler<GetTripAppUserByIdQuery, BaseResult<GetTripAppUserByIdQueryResult>>
{
    public async Task<BaseResult<GetTripAppUserByIdQueryResult>> Handle(GetTripAppUserByIdQuery request, CancellationToken cancellationToken)
    {
        var tripAppUser = await repository.GetByIdAsync(request.Id);
        if (tripAppUser == null)
        {
            return BaseResult<GetTripAppUserByIdQueryResult>.NotFound("Sefer kaydı bulunamadı.");
        }

        var result = mapper.Map<GetTripAppUserByIdQueryResult>(tripAppUser);
        return BaseResult<GetTripAppUserByIdQueryResult>.Success(result);
    }
}

