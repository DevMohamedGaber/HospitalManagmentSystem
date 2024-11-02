namespace Application.Common.Exceptions;

public class BadRequestException : Exception
{
    public string[] Errors { get; set; }

    public BadRequestException(string Msg) : base(Msg) { }

    public BadRequestException(string[] Errors) : base("Multiple errors occurred. See error details.")
    {
        this.Errors = Errors;
    }
}
