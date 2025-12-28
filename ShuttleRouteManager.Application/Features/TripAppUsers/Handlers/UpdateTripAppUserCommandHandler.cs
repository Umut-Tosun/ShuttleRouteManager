using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Handlers;

public class UpdateTripAppUserCommandHandler(
    IRepository<TripAppUser> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateTripAppUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateTripAppUserCommand request, CancellationToken cancellationToken)
    {
        var tripAppUser = mapper.Map<TripAppUser>(request);
        repository.Update(tripAppUser);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(tripAppUser);
    }
}

