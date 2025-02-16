using Microsoft.AspNetCore.Http;
using Payinvstock.Contract.Util.Http;
using Payinvstock.Util.Contants.Claims;

namespace Payinvstock.Util.Http;

public class UserHttpContextAccessor : IUserHttpContextAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Get current user id from session
    /// </summary>
    /// <returns></returns>
    public Guid GetCurrentUserId()
    {
        var currentUser = _httpContextAccessor
                .HttpContext?
                .User?
                .Claims?
                .FirstOrDefault(x => x.Type == GPAClaimTypes.UserId)?.Value;

        return Guid.Parse(currentUser ?? "00000000-0000-0000-0000-000000000001");
    }

    /// <summary>
    /// Get current user name from session
    /// </summary>
    /// <returns></returns>
    public string GetCurrentUserName()
    {
        var currentUserName = _httpContextAccessor
                .HttpContext?
                .User?
                .Claims?
                .FirstOrDefault(x => x.Type == GPAClaimTypes.FullName)?.Value;

        return currentUserName ?? "Test use";
    }
}