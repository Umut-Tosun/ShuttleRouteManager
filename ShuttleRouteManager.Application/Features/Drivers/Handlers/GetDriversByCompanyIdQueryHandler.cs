using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Drivers.Queries;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Handlers;

public class GetDriversByCompanyIdQueryHandler(
    IRepository<Driver> repository,
    IMapper mapper) : IRequestHandler<GetDriversByCompanyIdQuery, BaseResult<List<GetDriversQueryResult>>>
{
    public async Task<BaseResult<List<GetDriversQueryResult>>> Handle(GetDriversByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var drivers = await repository.GetAllAsync(d => d.CompanyId == request.CompanyId);
        var result = mapper.Map<List<GetDriversQueryResult>>(drivers);
        return BaseResult<List<GetDriversQueryResult>>.Success(result);
    }
}