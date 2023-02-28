using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(DataContext dataContext) : base(dataContext) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            IQueryable<User> query = CreateQuery(_dbSet);

            User? user = await query.SingleOrDefaultAsync(e => e.Email == email);
            return user;
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            IQueryable<User> query = CreateQuery(_dbSet);

            User? user = await query.SingleOrDefaultAsync(e => e.Id == id);
            return user;
        }
        public async Task<bool> IsEmailTakenAsync(string email, int? userId = null)
        {
            IQueryable<User> query = CreateQuery(_dbSet);

            User? user;
            if (userId != null) user = await query.SingleOrDefaultAsync(u => (u.Email == email) && (u.Id != userId));
            else user = await query.SingleOrDefaultAsync(u => u.Email == email);

            if (user != null) return true;
            return false;
        }

        protected override IQueryable<User> CreateQuery(DbSet<User> dbSet)
        {
            IQueryable<User> query = base.CreateQuery(dbSet);

            return query;
        }
    }
}
