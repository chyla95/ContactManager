using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace api.Extensions.BuilderConfiguration
{
    public static class Authentication
    {
        public static IServiceCollection SetupAuthentication(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            string? jwtSecretKey = Environment.GetEnvironmentVariable(EnvironmentVariables.JWT_SECRET);
            if (jwtSecretKey == null) throw new NullReferenceException(nameof(jwtSecretKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            services.AddSwaggerGen(configuration =>
            {
                configuration.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the bearer scheme, e.g. \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                configuration.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }
    }
}
