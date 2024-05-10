using System.Security.Claims;

namespace VTPAdmin.Extensions
{
    public static class GetUserExtension
    {
        public static string GetLoggedInUserExtension(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
