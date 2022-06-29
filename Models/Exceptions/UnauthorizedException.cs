using System.Runtime.Serialization;

namespace Contracts.Exceptions;

[Serializable]
public class UnauthorizedException : ApplicationException
{
    public UnauthorizedException()
    {
    }

    public UnauthorizedException(string message) : base(message)
    {
    }

    public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
