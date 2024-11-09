using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Domain.Entities;
using MediatR;
using Domain.Repositories;
using Infrastructure.Identity.Entities;

namespace Infrastructure.Identity.Features.Login;

public sealed class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IUserRepository _repository;
    private readonly UserManager<UserIdentity> _userManager;
    private readonly SignInManager<UserIdentity> _signInManager;

    public UserLoginHandler(IUserRepository repository, UserManager<UserIdentity> userManager, SignInManager<UserIdentity> signInManager)
    {
        _repository = repository;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<UserLoginResponse> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return new UserLoginResponse("Couldn't find this email address in our database");
        }

        var flag = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!flag)
        {
            return new UserLoginResponse("Wrong Password");
        }

        await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Email, user.Email));

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

        if (result.IsNotAllowed)
        {
            return new UserLoginResponse("Your account is not confirmed yet");
        }

        if (result.IsLockedOut)
        {
            return new UserLoginResponse("Your account is locked!!");
        }

        return new UserLoginResponse(true);
    }
}
