using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Buses.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Handlers;

public class CreateBusCommandHandler(
IRepository<Bus> repository,
IMapper mapper,
IUnitOfWork unitOfWork) : IRequestHandler<CreateBusCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateBusCommand request, CancellationToken cancellationToken)
    {
        var bus = mapper.Map<Bus>(request);
        await repository.CreateAsync(bus);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(bus);
    }
}
