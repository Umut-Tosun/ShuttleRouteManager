using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Buses.Queries;
using ShuttleRouteManager.Application.Features.Buses.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Buses.Handlers;

public class GetBusByIdQueryHandler(
    IRepository<Bus> repository,
    IMapper mapper) : IRequestHandler<GetBusByIdQuery, BaseResult<GetBusByIdQueryResult>>
{
    public async Task<BaseResult<GetBusByIdQueryResult>> Handle(GetBusByIdQuery request, CancellationToken cancellationToken)
    {
        var bus = await repository.GetQuery()
            .Include(b => b.Company)
            .Include(b => b.DefaultDriver) 
            .Include(b => b.Routes)
                .ThenInclude(r => r.Driver)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (bus == null)
            return BaseResult<GetBusByIdQueryResult>.Failure("Otobüs bulunamadı");

        var result = mapper.Map<GetBusByIdQueryResult>(bus);

        return BaseResult<GetBusByIdQueryResult>.Success(result);
    }
}