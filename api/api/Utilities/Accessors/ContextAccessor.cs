using api.Models;
using System.Security.Claims;

namespace api.Utilities.Accessors
{
    public class ContextAccessor : IContextAccessor
    {
        private readonly HttpContext _httpContext;

        public ContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext? httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null) throw new NullReferenceException(nameof(httpContext));
            _httpContext = httpContext;
        }

        public IEnumerable<Claim> GetUserClaims()
        {
            ClaimsPrincipal claimsPrincipal = _httpContext.User;
            IEnumerable<Claim> claims = claimsPrincipal.Claims;

            return claims;
        }
        public void SetUser(User user)
        {
            IDictionary<object, object?> contextItems = _httpContext.Items;
            contextItems.Add(HttpContextItemKeys.USER, user);
        }
        public User GetUser()
        {
            IDictionary<object, object?> contextItems = _httpContext.Items;
            User? user = (User?)contextItems[HttpContextItemKeys.USER];
            if (user == null) throw new NullReferenceException(nameof(user));

            return user;
        }
    }
}
