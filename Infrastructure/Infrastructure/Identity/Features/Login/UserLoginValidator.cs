using FluentValidation;

namespace Infrastructure.Identity.Features.Login;

public sealed class UserLoginValidator : AbstractValidator<UserLoginRequest>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MinimumLength(10).MaximumLength(50).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}
