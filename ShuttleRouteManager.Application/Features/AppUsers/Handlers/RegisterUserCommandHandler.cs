using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.AppUsers.Handlers;

public class RegisterUserCommandHandler(
UserManager<AppUser> userManager,
IMapper mapper) : IRequestHandler<RegisterUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<AppUser>(request);
        user.UserName = request.Email;

        var result = await userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            return BaseResult<object>.Success("Kullanıcı başarıyla oluşturuldu.");
        }

        return BaseResult<object>.Failure(result.Errors);
    }
}




