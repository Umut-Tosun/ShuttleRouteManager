using FluentValidation;
using ShuttleRouteManager.Application.Features.Drivers.Commands;

namespace ShuttleRouteManager.Application.Features.Drivers.Validators;

public class CreateDriverValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Sürücü adı zorunludur.")
            .MaximumLength(50).WithMessage("Sürücü adı en fazla 50 karakter olabilir.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Sürücü soyadı zorunludur.")
            .MaximumLength(50).WithMessage("Sürücü soyadı en fazla 50 karakter olabilir.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası zorunludur.")
            .Matches(@"^[0-9]{10}$").WithMessage("Geçerli bir telefon numarası giriniz (10 haneli).");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("Ehliyet numarası zorunludur.")
            .MaximumLength(20).WithMessage("Ehliyet numarası en fazla 20 karakter olabilir.");

        RuleFor(x => x.JobStartDate)
            .NotEmpty().WithMessage("İşe başlama tarihi zorunludur.")
            .LessThanOrEqualTo(DateTimeOffset.Now).WithMessage("İşe başlama tarihi gelecek bir tarih olamaz.");

        RuleFor(x => x.CompanyId)
            .NotEmpty().WithMessage("Şirket seçimi zorunludur.");
    }
}
