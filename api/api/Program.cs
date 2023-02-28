using Microsoft.EntityFrameworkCore;
using api.DataAccess;
using api.Middlewares;
using api.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.Filters;
using api.Utilities.Accessors;

// Get application settings
string? jwtSecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
if (jwtSecretKey == null) throw new NullReferenceException(nameof(jwtSecretKey));
//string? dbConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
//if (dbConnectionString == null) throw new NullReferenceException(nameof(dbConnectionString));

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect to the database
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=cm-database,1433;Database=ContactManager;Integrated Security=false;User ID=sa;Password=Ubzm6Y2xrCmsnh!Ubf6dNhEQLKxeQNy;TrustServerCertificate=True"));

// Services
builder.Services.AddTransient<IEnvironmentVariablesAccessor, EnvironmentVariablesAccessor>();
builder.Services.AddTransient<IContextAccessor, ContextAccessor>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
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
builder.Services.AddSwaggerGen(configuration =>
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



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseSwagger();
if (app.Environment.IsDevelopment()) app.UseSwaggerUI();
app.SetupExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthentication();
app.SetupAuthenticationHandler();
app.UseAuthorization();
app.MapControllers();
app.Run();
