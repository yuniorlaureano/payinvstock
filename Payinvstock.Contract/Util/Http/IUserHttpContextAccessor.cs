namespace Payinvstock.Contract.Util.Http;

public interface IUserHttpContextAccessor
{
    /// <summary>
    /// Get current user id from session
    /// </summary>
    /// <returns></returns>
    Guid GetCurrentUserId();

    /// <summary>
    /// Get current user name from session
    /// </summary>
    /// <returns></returns>
    string GetCurrentUserName();
}