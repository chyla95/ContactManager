using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
// dotnet tool install --global dotnet-ef