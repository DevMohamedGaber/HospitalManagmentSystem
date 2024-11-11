using FluentValidation;

namespace Application.Features.Patient.Login;

public class PatientLoginValidator : AbstractValidator<PatientLoginRequest>
{
    public PatientLoginValidator()
    {
        RuleFor(x => x.NationalID).NotEmpty().Length(21);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}
