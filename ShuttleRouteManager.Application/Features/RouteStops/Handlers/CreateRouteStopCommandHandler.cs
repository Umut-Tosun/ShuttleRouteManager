using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.RouteStops.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.RouteStops.Handlers;

public class CreateRouteStopCommandHandler(
IRepository<RouteStop> repository,
IMapper mapper,
IUnitOfWork unitOfWork) : IRequestHandler<CreateRouteStopCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateRouteStopCommand request, CancellationToken cancellationToken)
    {
        var routeStop = mapper.Map<RouteStop>(request);
        await repository.CreateAsync(routeStop);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(routeStop);
    }
}
