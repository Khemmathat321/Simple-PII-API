namespace Application.Exceptions;

public class EmailAlreadyExistException : Exception
{
    public override string Message { get; } = "Email already exist";
}
