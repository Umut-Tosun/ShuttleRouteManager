using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.Companies.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.Companies.Handlers;

public class RemoveCompanyCommandHandler(
    IRepository<Company> repository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveCompanyCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await repository.GetByIdAsync(request.Id);
        if (company == null)
        {
            return BaseResult<object>.NotFound("Şirket bulunamadı.");
        }

        repository.Delete(company);
        await unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success(company);
    }
}