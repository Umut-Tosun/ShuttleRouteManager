using FluentValidation;
using ShuttleRouteManager.Application.Features.RouteStops.Commands;

namespace ShuttleRouteManager.Application.Features.RouteStops.Validators;

public class CreateRouteStopValidator : AbstractValidator<CreateRouteStopCommand>
{
    public CreateRouteStopValidator()
    {
        RuleFor(x => x.SequenceNumber)
            .GreaterThan(0).WithMessage("Sıra numarası 0'dan büyük olmalıdır.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Şehir zorunludur.")
            .MaximumLength(50).WithMessage("Şehir en fazla 50 karakter olabilir.");

        RuleFor(x => x.District)
            .NotEmpty().WithMessage("İlçe zorunludur.")
            .MaximumLength(50).WithMessage("İlçe en fazla 50 karakter olabilir.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Adres zorunludur.")
            .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.");

        RuleFor(x => x.Latitude)
            .NotEmpty().WithMessage("Enlem zorunludur.")
            .InclusiveBetween(-90, 90).WithMessage("Enlem -90 ile 90 arasında olmalıdır.");

        RuleFor(x => x.Longitude)
            .NotEmpty().WithMessage("Boylam zorunludur.")
            .InclusiveBetween(-180, 180).WithMessage("Boylam -180 ile 180 arasında olmalıdır.");

        RuleFor(x => x.EstimatedArrivalTimeMorning)
            .NotEmpty().WithMessage("Sabah tahmini varış saati zorunludur.");

        RuleFor(x => x.EstimatedArrivalTimeEvening)
            .NotEmpty().WithMessage("Akşam tahmini varış saati zorunludur.");

        RuleFor(x => x.RouteId)
            .NotEmpty().WithMessage("Rota seçimi zorunludur.");
    }
}
