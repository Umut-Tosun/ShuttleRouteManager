using AutoMapper;
using MediatR;
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
        var bus = await repository.GetByIdAsync(request.Id);
        if (bus == null)
        {
            return BaseResult<GetBusByIdQueryResult>.NotFound("Otobüs bulunamadı.");
        }

        var result = mapper.Map<GetBusByIdQueryResult>(bus);
        return BaseResult<GetBusByIdQueryResult>.Success(result);
    }
}