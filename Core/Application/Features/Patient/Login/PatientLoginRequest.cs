using MediatR;

namespace Application.Features.Patient.Login;

public class PatientLoginRequest : IRequest<PatientLoginResponse>
{
    public string? NationalID { get; set; }
    public string? Password { get; set; }
}
