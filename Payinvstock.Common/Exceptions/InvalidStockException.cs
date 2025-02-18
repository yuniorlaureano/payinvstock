using Payinvstock.Common.Constants;

namespace Payinvstock.Common.Exceptions;

public class InvalidStockException : Exception
{
    public InvalidStockException() : base(ExceptionCodes.InvalidStock)
    {
    }

    public InvalidStockException(string message) : base($"{ExceptionCodes.InvalidStock}: {message}")
    {
    }
}