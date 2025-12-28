using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Commands;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.AppUsers.Handlers;

public class UpdateUserCommandHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<UpdateUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            return BaseResult<object>.NotFound("Kullanıcı bulunamadı.");
        }

        mapper.Map(request, user);
        var result = await userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return BaseResult<object>.Success("Kullanıcı başarıyla güncellendi.");
        }

        return BaseResult<object>.Failure(result.Errors);
    }
}