using api.DataAccess;
using api.Extensions.BuilderConfiguration;
using api.Middlewares;
using api.Services;
using api.Utilities.Accessors;
using Microsoft.EntityFrameworkCore;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Services
builder.Services.AddTransient<IEnvironmentVariablesAccessor, EnvironmentVariablesAccessor>();
builder.Services.AddTransient<IContextAccessor, ContextAccessor>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IContactService, ContactService>();
// Tools and utilities
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.SetupAuthentication();
builder.Services.SetupDatabase();

var app = builder.Build();

#region AutoMigrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseSwagger();
if (app.Environment.IsDevelopment()) app.UseSwaggerUI();
app.SetupExceptionHandler();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.SetupAuthenticationHandler();
app.UseAuthorization();
app.MapControllers();
app.Run();
