using AutoMapper;
using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Companies.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Handlers;

public class UpdateCompanyCommandHandler(
    IRepository<Company> repository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateCompanyCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = mapper.Map<Company>(request);
        repository.Update(company);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(company);
    }
}
