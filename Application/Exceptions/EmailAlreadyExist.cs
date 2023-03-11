namespace Application.Exceptions;

public class EmailAlreadyExist : Exception
{
    public override string Message { get; } = "Email already exist";
}
