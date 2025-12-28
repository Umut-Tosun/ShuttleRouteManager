using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Handlers;

public class RemoveTripAppUserCommandHandler(
    IRepository<TripAppUser> repository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveTripAppUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveTripAppUserCommand request, CancellationToken cancellationToken)
    {
        var tripAppUser = await repository.GetByIdAsync(request.Id);
        if (tripAppUser == null)
        {
            return BaseResult<object>.NotFound("Sefer kaydı bulunamadı.");
        }

        repository.Delete(tripAppUser);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(tripAppUser);
    }
}


