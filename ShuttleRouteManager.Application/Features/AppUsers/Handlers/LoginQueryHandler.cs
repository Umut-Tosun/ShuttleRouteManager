using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Contracts.Persistence;
using ShuttleRouteManager.Application.Features.AppUsers.Queries;
using ShuttleRouteManager.Application.Features.AppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.AppUsers.Handlers;

public class LoginQueryHandler(
    UserManager<AppUser> userManager,
    IJwtService jwtService,
    IMapper mapper) : IRequestHandler<LoginQuery, BaseResult<LoginQueryResult>>
{
    public async Task<BaseResult<LoginQueryResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return BaseResult<LoginQueryResult>.Failure("E-posta veya şifre hatalı.");
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
        {
            return BaseResult<LoginQueryResult>.Failure("E-posta veya şifre hatalı.");
        }

        var userResult = mapper.Map<GetAppUsersQueryResult>(user);
        var tokenResult = await jwtService.GenerateTokenAsync(userResult);

        return BaseResult<LoginQueryResult>.Success(tokenResult);
    }
}