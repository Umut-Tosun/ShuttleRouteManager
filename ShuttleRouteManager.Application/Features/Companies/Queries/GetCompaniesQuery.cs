using MediatR;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.Companies.Result;

namespace ShuttleRouteManager.Application.Features.Companies.Queries;

public record GetCompaniesQuery : IRequest<BaseResult<List<GetCompaniesQueryResult>>>;





