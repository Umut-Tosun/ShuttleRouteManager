using FluentValidation;
using ShuttleRouteManager.Application.Features.Routes.Commands;

namespace ShuttleRouteManager.Application.Features.Routes.Validators;

public class CreateRouteValidator : AbstractValidator<CreateRouteCommand>
{
    public CreateRouteValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Rota adı zorunludur.")
            .MaximumLength(100).WithMessage("Rota adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.StartPoint)
            .NotEmpty().WithMessage("Başlangıç noktası zorunludur.")
            .MaximumLength(200).WithMessage("Başlangıç noktası en fazla 200 karakter olabilir.");

        RuleFor(x => x.EndPoint)
            .NotEmpty().WithMessage("Bitiş noktası zorunludur.")
            .MaximumLength(200).WithMessage("Bitiş noktası en fazla 200 karakter olabilir.");

        RuleFor(x => x.MorningStartTime)
            .NotEmpty().WithMessage("Sabah başlangıç saati zorunludur.")
            .LessThan(TimeSpan.FromHours(12)).WithMessage("Sabah başlangıç saati öğleden önce olmalıdır.");

        RuleFor(x => x.EveningStartTime)
            .NotEmpty().WithMessage("Akşam başlangıç saati zorunludur.")
            .GreaterThan(TimeSpan.FromHours(12)).WithMessage("Akşam başlangıç saati öğleden sonra olmalıdır.");

        RuleFor(x => x.BusId)
            .NotEmpty().WithMessage("Otobüs seçimi zorunludur.");

        RuleFor(x => x.DriverId)
            .NotEmpty().WithMessage("Sürücü seçimi zorunludur.");
    }
}
