using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;
using ShuttleRouteManager.Application.Features.TripAppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Handlers;

public class UpdateTripAppUserCommandHandler(
    IRepository<TripAppUser> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateTripAppUserCommand, BaseResult<GetTripAppUserByIdQueryResult>>
{
    public async Task<BaseResult<GetTripAppUserByIdQueryResult>> Handle(UpdateTripAppUserCommand request, CancellationToken cancellationToken)
    {
        // Önce var olan entity'yi getir
        var existingTrip = await repository.GetByIdAsync(request.Id);
        if (existingTrip == null)
        {
            return BaseResult<GetTripAppUserByIdQueryResult>.NotFound("Sefer kaydı bulunamadı.");
        }

        // Güncelleme yap
        mapper.Map(request, existingTrip);

        repository.Update(existingTrip);
        await unitOfWork.SaveChangesAsync();

        var result = mapper.Map<GetTripAppUserByIdQueryResult>(existingTrip);
        return BaseResult<GetTripAppUserByIdQueryResult>.Success(result);
    }
}