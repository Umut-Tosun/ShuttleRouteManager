using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Commands;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class UpdateRouteCommandHandler(
    IRepository<Domain.Entities.Route> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateRouteCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        var route = mapper.Map<Domain.Entities.Route>(request);
        repository.Update(route);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(route);
    }
}