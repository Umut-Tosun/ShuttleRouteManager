using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Drivers.Queries;
using ShuttleRouteManager.Application.Features.Drivers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Drivers.Handlers;

public class GetDriverByIdQueryHandler(
    IRepository<Driver> repository,
    IMapper mapper) : IRequestHandler<GetDriverByIdQuery, BaseResult<GetDriverByIdQueryResult>>
{
    public async Task<BaseResult<GetDriverByIdQueryResult>> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
    {
        var driver = await repository.GetByIdAsync(request.Id);
        if (driver == null)
        {
            return BaseResult<GetDriverByIdQueryResult>.NotFound("Sürücü bulunamadı.");
        }

        var result = mapper.Map<GetDriverByIdQueryResult>(driver);
        return BaseResult<GetDriverByIdQueryResult>.Success(result);
    }
}