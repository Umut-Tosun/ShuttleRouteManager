using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ShuttleRouteManager.Application.Base;
using ShuttleRouteManager.Application.Features.AppUsers.Queries;
using ShuttleRouteManager.Application.Features.AppUsers.Result;
using ShuttleRouteManager.Domain.Entities;

namespace ShuttleRouteManager.Application.Features.AppUsers.Handlers;

public class GetUserByIdQueryHandler(
    UserManager<AppUser> userManager,
    IMapper mapper) : IRequestHandler<GetUserByIdQuery, BaseResult<GetUserByIdQueryResult>>
{
    public async Task<BaseResult<GetUserByIdQueryResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            return BaseResult<GetUserByIdQueryResult>.NotFound("Kullanıcı bulunamadı.");
        }

        var result = mapper.Map<GetUserByIdQueryResult>(user);
        return BaseResult<GetUserByIdQueryResult>.Success(result);
    }
}




