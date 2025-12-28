using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Queries;
using ShuttleRouteManager.Application.Features.AppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.AppUsers.Handlers;

public class GetUsersQueryHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<GetUsersQuery, BaseResult<List<GetAppUsersQueryResult>>>
{
    public async Task<BaseResult<List<GetAppUsersQueryResult>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken);
        var result = mapper.Map<List<GetAppUsersQueryResult>>(users);
        return BaseResult<List<GetAppUsersQueryResult>>.Success(result);
    }
}