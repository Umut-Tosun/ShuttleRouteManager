using FluentValidation;
using ShuttleRouteManager.Application.Features.TripAppUsers.Commands;

namespace ShuttleRouteManager.Application.Features.TripAppUsers.Validators;

public class UpdateTripAppUserValidator : AbstractValidator<UpdateTripAppUserCommand>
{
    public UpdateTripAppUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id zorunludur.");

        RuleFor(x => x.AppUserId)
            .NotEmpty().WithMessage("Kullanıcı seçilmelidir.");

        RuleFor(x => x.RouteId)
            .NotEmpty().WithMessage("Rota seçilmelidir.");

        RuleFor(x => x.RouteStopId)
            .NotEmpty().WithMessage("Durak seçilmelidir.");

        // En az biri aktif olmalı
        RuleFor(x => x)
            .Must(x => x.IsMorningTripActive || x.IsEveningTripActive)
            .WithMessage("En az bir sefer tipi (Sabah veya Akşam) seçilmelidir.");

        RuleFor(x => x.ValidFrom)
            .NotNull().WithMessage("Geçerlilik başlangıç tarihi zorunludur.");

        RuleFor(x => x.ValidUntil)
            .NotNull().WithMessage("Geçerlilik bitiş tarihi zorunludur.")
            .GreaterThan(x => x.ValidFrom).WithMessage("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
    }
}