using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Buses.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Handlers;

public class RemoveBusCommandHandler(
    IRepository<Bus> repository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveBusCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveBusCommand request, CancellationToken cancellationToken)
    {
        var bus = await repository.GetByIdAsync(request.Id);
        if (bus == null)
        {
            return BaseResult<object>.NotFound("Otobüs bulunamadı.");
        }

        repository.Delete(bus);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(bus);
    }
}