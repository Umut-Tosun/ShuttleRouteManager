using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Companies.Commands;

public class CreateCompanyCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ResponsiblePerson { get; set; } = default!;
    public string ResponsiblePersonPhoneNumber { get; set; } = default!;
    public string TaxOffice { get; set; } = default!;
    public string TaxNumber { get; set; } = default!;
    public DateTimeOffset ContractDate { get; set; }
    public DateTimeOffset ContractEndDate { get; set; }
}
