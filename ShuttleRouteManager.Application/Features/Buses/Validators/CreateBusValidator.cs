using FluentValidation;
using ShuttleRouteManager.Application.Features.Buses.Commands;

namespace ShuttleRouteManager.Application.Features.Buses.Validators;

public class CreateBusValidator : AbstractValidator<CreateBusCommand>
{
    public CreateBusValidator()
    {
        RuleFor(x => x.PlateNo)
            .NotEmpty().WithMessage("Plaka numarası zorunludur.")
            .Matches(@"^[0-9]{2}[A-Z]{1,3}[0-9]{2,4}$").WithMessage("Geçerli bir plaka numarası giriniz (ör: 34ABC123).")
            .MaximumLength(10).WithMessage("Plaka numarası en fazla 10 karakter olabilir.");

        RuleFor(x => x.Brand)
            .NotEmpty().WithMessage("Marka zorunludur.")
            .MaximumLength(50).WithMessage("Marka en fazla 50 karakter olabilir.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model zorunludur.")
            .MaximumLength(50).WithMessage("Model en fazla 50 karakter olabilir.");

        RuleFor(x => x.Year)
            .NotEmpty().WithMessage("Model yılı zorunludur.")
            .GreaterThan(1990).WithMessage("Model yılı 1990'dan büyük olmalıdır.")
            .LessThanOrEqualTo(DateTime.Now.Year + 1).WithMessage("Model yılı gelecek yıl olarak girilemez.");

        RuleFor(x => x.Capacity)
            .NotEmpty().WithMessage("Kapasite zorunludur.")
            .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(100).WithMessage("Kapasite en fazla 100 olabilir.");

        RuleFor(x => x.Km)
            .GreaterThanOrEqualTo(0).WithMessage("Kilometre 0'dan küçük olamaz.");

        RuleFor(x => x.CompanyId)
            .NotEmpty().WithMessage("Şirket seçimi zorunludur.");

        // DefaultDriverId opsiyonel, validasyon gereksiz
    }
}