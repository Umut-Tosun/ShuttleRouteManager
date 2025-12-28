using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Routing;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Commands;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class CreateRouteCommandHandler(
IRepository<Domain.Entities.Route> repository,
IMapper mapper,
IUnitOfWork unitOfWork) : IRequestHandler<CreateRouteCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        var route = mapper.Map<Domain.Entities.Route>(request);
        await repository.CreateAsync(route);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(route);
    }
}



