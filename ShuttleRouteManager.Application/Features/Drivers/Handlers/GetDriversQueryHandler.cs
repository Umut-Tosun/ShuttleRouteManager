using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Drivers.Queries;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Handlers;

public class GetDriversQueryHandler(
    IRepository<Driver> repository,
    IMapper mapper) : IRequestHandler<GetDriversQuery, BaseResult<List<GetDriversQueryResult>>>
{
    public async Task<BaseResult<List<GetDriversQueryResult>>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await repository.GetAllAsync();
        var result = mapper.Map<List<GetDriversQueryResult>>(drivers);
        return BaseResult<List<GetDriversQueryResult>>.Success(result);
    }
}