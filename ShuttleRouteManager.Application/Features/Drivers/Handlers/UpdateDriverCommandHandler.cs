using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Drivers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Handlers;

public class UpdateDriverCommandHandler(
    IRepository<Driver> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateDriverCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = mapper.Map<Driver>(request);
        repository.Update(driver);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(driver);
    }
}
