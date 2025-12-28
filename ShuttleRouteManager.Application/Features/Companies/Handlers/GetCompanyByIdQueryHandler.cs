using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Companies.Queries;
using ShuttleRouteManager.Application.Features.Companies.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Handlers;

public class GetCompanyByIdQueryHandler(
    IRepository<Company> repository,
    IMapper mapper) : IRequestHandler<GetCompanyByIdQuery, BaseResult<GetCompanyByIdQueryResult>>
{
    public async Task<BaseResult<GetCompanyByIdQueryResult>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await repository.GetByIdAsync(request.Id);
        if (company == null)
        {
            return BaseResult<GetCompanyByIdQueryResult>.NotFound("Şirket bulunamadı.");
        }

        var result = mapper.Map<GetCompanyByIdQueryResult>(company);
        return BaseResult<GetCompanyByIdQueryResult>.Success(result);
    }
}
