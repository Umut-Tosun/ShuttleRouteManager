using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Drivers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Handlers;

public class RemoveDriverCommandHandler(
    IRepository<Driver> repository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveDriverCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await repository.GetByIdAsync(request.Id);
        if (driver == null)
        {
            return BaseResult<object>.NotFound("Sürücü bulunamadı.");
        }

        repository.Delete(driver);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(driver);
    }
}