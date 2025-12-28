using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.RouteStops.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.RouteStops.Handlers;

public class UpdateRouteStopCommandHandler(
    IRepository<RouteStop> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateRouteStopCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateRouteStopCommand request, CancellationToken cancellationToken)
    {
        var routeStop = mapper.Map<RouteStop>(request);
        repository.Update(routeStop);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(routeStop);
    }
}