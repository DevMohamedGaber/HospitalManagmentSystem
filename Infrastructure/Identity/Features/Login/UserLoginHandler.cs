using Microsoft.AspNetCore.Identity;
using Persistence.Identity.Entities;
using System.Security.Claims;
using MediatR;
using Persistence.Identity.Repositories;

namespace Persistence.Identity.Features.Login;

public sealed class UserLoginHandler : IRequestHandler<UserLoginRequest, UserLoginResponse>
{
    private readonly IUserRepository _repository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserLoginHandler(IUserRepository repository, UserManager<User> userManager, SignInManager<User> signInManager)
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
            return new UserLoginResponse("Invalid Email Address");
        }

        var flag = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!flag)
        {
            return new UserLoginResponse("Invalid Password");
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
