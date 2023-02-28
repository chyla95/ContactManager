using api.Exceptions;
using api.Models;
using api.Services;
using api.Utilities.Accessors;
using System.Numerics;
using System.Security.Claims;

namespace api.Middlewares
{
    public class AuthenticationHandler
    {
        private readonly RequestDelegate _next;

        public AuthenticationHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserService userService, IContextAccessor contextAccessor)
        {
            IEnumerable<Claim> userClaims = contextAccessor.GetUserClaims();
            Claim? userIdClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if(userIdClaim != null)
            {
                bool isIdValid = int.TryParse(userIdClaim.Value, out int userId);

                if (!isIdValid) throw new HttpUnauthorizedException("Invalid userId!");

                User? user = await userService.GetByIdAsync(userId);
                if (user == null) throw new HttpUnauthorizedException("User does not exist!");
                contextAccessor.SetUser(user);
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationHandlerExtensions
    {
        public static IApplicationBuilder SetupAuthenticationHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationHandler>();
        }
    }
}
