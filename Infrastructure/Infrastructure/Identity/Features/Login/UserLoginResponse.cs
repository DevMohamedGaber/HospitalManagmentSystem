namespace Infrastructure.Identity.Features.Login;

public class UserLoginResponse
{
    public bool status { get; set; }
    public string? errorMsg { get; set; }

    public UserLoginResponse(string errorMsg)
    {
        this.errorMsg = errorMsg;
    }
    public UserLoginResponse(bool status)
    {
        this.status = status;
    }
}
