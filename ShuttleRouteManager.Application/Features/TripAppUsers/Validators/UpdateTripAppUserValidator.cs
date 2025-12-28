using FluentValidation;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Validators;

public class UpdateTripAppUserValidator : AbstractValidator<UpdateTripAppUserCommand>
{
    public UpdateTripAppUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Sefer ID zorunludur.");

        RuleFor(x => x.AppUserId)
            .NotEmpty().WithMessage("Kullanıcı seçimi zorunludur.");

        RuleFor(x => x.RouteId)
            .NotEmpty().WithMessage("Rota seçimi zorunludur.");

        RuleFor(x => x.RouteStopId)
            .NotEmpty().WithMessage("Durak seçimi zorunludur.");

        RuleFor(x => x.TripType)
            .IsInEnum().WithMessage("Geçerli bir sefer tipi seçiniz.");

        RuleFor(x => x.ValidFrom)
            .LessThan(x => x.ValidUntil)
            .When(x => x.ValidFrom.HasValue && x.ValidUntil.HasValue)
            .WithMessage("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
    }
}