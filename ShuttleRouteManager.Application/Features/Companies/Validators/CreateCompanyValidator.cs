using FluentValidation;
using ShuttleRouteManager.Application.Features.Companies.Commands;

namespace ShuttleRouteManager.Application.Features.Companies.Validators;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Şirket adı zorunludur.")
            .MaximumLength(200).WithMessage("Şirket adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Adres zorunludur.")
            .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.");

        RuleFor(x => x.ResponsiblePerson)
            .NotEmpty().WithMessage("Sorumlu kişi adı zorunludur.")
            .MaximumLength(100).WithMessage("Sorumlu kişi adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.ResponsiblePersonPhoneNumber)
            .NotEmpty().WithMessage("Sorumlu kişi telefonu zorunludur.")
            .Matches(@"^[0-9]{10}$").WithMessage("Geçerli bir telefon numarası giriniz (10 haneli).");

        RuleFor(x => x.TaxOffice)
            .NotEmpty().WithMessage("Vergi dairesi zorunludur.")
            .MaximumLength(100).WithMessage("Vergi dairesi en fazla 100 karakter olabilir.");

        RuleFor(x => x.TaxNumber)
            .NotEmpty().WithMessage("Vergi numarası zorunludur.")
            .Matches(@"^[0-9]{10}$").WithMessage("Vergi numarası 10 haneli olmalıdır.");

        RuleFor(x => x.ContractDate)
            .NotEmpty().WithMessage("Sözleşme tarihi zorunludur.");

        RuleFor(x => x.ContractEndDate)
            .NotEmpty().WithMessage("Sözleşme bitiş tarihi zorunludur.")
            .GreaterThan(x => x.ContractDate).WithMessage("Sözleşme bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
    }
}
