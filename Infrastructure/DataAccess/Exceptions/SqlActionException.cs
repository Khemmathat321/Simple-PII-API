namespace Infrastructure.DataAccess.Exceptions;

public class SqlActionException : Exception
{
    public SqlActionException(string action, string entity)
    {
        Message = $"Can't {action} {entity}";
    }

    public override string Message { get; }
}
