using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Buses.Queries;
using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Handlers;

public class GetBusesByCompanyIdQueryHandler(
    IRepository<Bus> repository,
    IMapper mapper) : IRequestHandler<GetBusesByCompanyIdQuery, BaseResult<List<GetBusesQueryResult>>>
{
    public async Task<BaseResult<List<GetBusesQueryResult>>> Handle(GetBusesByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var buses = await repository.GetAllAsync(b => b.CompanyId == request.CompanyId);
        var result = mapper.Map<List<GetBusesQueryResult>>(buses);
        return BaseResult<List<GetBusesQueryResult>>.Success(result);
    }
}