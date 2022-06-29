using System.Runtime.Serialization;

namespace Contracts.Exceptions;

[Serializable]
public class BadRequestException : ApplicationException
{
    public BadRequestException()
    {
    }
    public bool ShowStackTrace { get; set; } = true;

    public BadRequestException(string message, bool showStackTrace = true) : base(message)
    {
        ShowStackTrace = showStackTrace;
    }

    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
