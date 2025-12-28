using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Drivers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Handlers;

public class CreateDriverCommandHandler(
IRepository<Driver> repository,
IMapper mapper,
IUnitOfWork unitOfWork) : IRequestHandler<CreateDriverCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = mapper.Map<Driver>(request);
        await repository.CreateAsync(driver);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(driver);
    }
}
