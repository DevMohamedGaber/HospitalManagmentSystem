namespace Application.Features.Patient.Login;

public class PatientLoginResponse
{
    public string? errorMsg { get; set; }

    public PatientLoginResponse()
    {
        
    }
    public PatientLoginResponse(string errorMsg)
    {
        this.errorMsg = errorMsg;
    }
}
