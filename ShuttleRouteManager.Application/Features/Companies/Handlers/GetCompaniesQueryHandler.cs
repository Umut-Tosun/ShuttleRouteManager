using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Companies.Queries;
using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Handlers;

public class GetCompaniesQueryHandler(
    IRepository<Company> repository,
    IMapper mapper) : IRequestHandler<GetCompaniesQuery, BaseResult<List<GetCompaniesQueryResult>>>
{
    public async Task<BaseResult<List<GetCompaniesQueryResult>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAllAsync();
        var result = mapper.Map<List<GetCompaniesQueryResult>>(companies);
        return BaseResult<List<GetCompaniesQueryResult>>.Success(result);
    }
}