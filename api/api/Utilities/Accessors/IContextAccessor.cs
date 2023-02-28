using api.Models;
using System.Security.Claims;

namespace api.Utilities.Accessors
{
    public interface IContextAccessor
    {
        IEnumerable<Claim> GetUserClaims();
        void SetUser(User user);
        User GetUser();
    }
}
