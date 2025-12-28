using MediatR;
using ShuttleRouteManager.Application.Base;

namespace ShuttleRouteManager.Application.Features.Companies.Commands;

public record RemoveCompanyCommand(Guid Id) : IRequest<BaseResult<object>>;
