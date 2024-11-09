using MediatR;

namespace Infrastructure.Identity.Features.Login;

public sealed class UserLoginRequest : IRequest<UserLoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
