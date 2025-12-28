using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Routes.Queries;
using ShuttleRouteManager.Application.Features.Routes.Result;

namespace ShuttleRouteManager.Application.Features.Routes.Handlers;

public class GetRouteByIdQueryHandler(
    IRepository<Domain.Entities.Route> repository,
    IMapper mapper) : IRequestHandler<GetRouteByIdQuery, BaseResult<GetRouteByIdQueryResult>>
{
    public async Task<BaseResult<GetRouteByIdQueryResult>> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
    {
        var route = await repository.GetByIdAsync(request.Id);
        if (route == null)
        {
            return BaseResult<GetRouteByIdQueryResult>.NotFound("Rota bulunamadı.");
        }

        var result = mapper.Map<GetRouteByIdQueryResult>(route);
        return BaseResult<GetRouteByIdQueryResult>.Success(result);
    }
}