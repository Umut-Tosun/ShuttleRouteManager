using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Buses.Queries;
using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Handlers;

public class GetBusesQueryHandler(
    IRepository<Bus> repository,
    IMapper mapper) : IRequestHandler<GetBusesQuery, BaseResult<List<GetBusesQueryResult>>>
{
    public async Task<BaseResult<List<GetBusesQueryResult>>> Handle(GetBusesQuery request, CancellationToken cancellationToken)
    {
        var buses = await repository.GetQuery()
            .Include(b => b.Company)
            .Include(b => b.DefaultDriver) 
            .Include(b => b.Routes)
                .ThenInclude(r => r.Driver)
            .ToListAsync(cancellationToken);

        var result = mapper.Map<List<GetBusesQueryResult>>(buses);

        return BaseResult<List<GetBusesQueryResult>>.Success(result);
    }
}