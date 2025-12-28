using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Commands;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class RemoveRouteCommandHandler(
    IRepository<Domain.Entities.Route> repository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveRouteCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveRouteCommand request, CancellationToken cancellationToken)
    {
        var route = await repository.GetByIdAsync(request.Id);
        if (route == null)
        {
            return BaseResult<object>.NotFound("Rota bulunamadı.");
        }

        repository.Delete(route);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(route);
    }
}