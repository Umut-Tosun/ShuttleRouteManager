using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Companies.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Handlers;

public class CreateCompanyCommandHandler(
 IRepository<Company> repository,
 IMapper mapper,
 IUnitOfWork unitOfWork) : IRequestHandler<CreateCompanyCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<Company>(request);
        await repository.CreateAsync(company);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(company);
    }
}
