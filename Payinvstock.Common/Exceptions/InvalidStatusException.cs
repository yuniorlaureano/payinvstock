using Payinvstock.Common.Constants;

namespace Payinvstock.Common.Exceptions;

public class InvalidStatusException : Exception
{
    public InvalidStatusException() : base(ExceptionCodes.InvalidStatus)
    {
    }

    public InvalidStatusException(string message) : base($"{ExceptionCodes.InvalidStatus}: {message}")
    {
    }
}