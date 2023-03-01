using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ContactService : Service<Contact>, IContactService
    {
        public ContactService(DataContext dataContext) : base(dataContext) { }

        public virtual async Task<IEnumerable<Contact>> GetManyByOwnerAsync(int id, bool isTrackingEnabled = true)
        {
            IQueryable<Contact> query = CreateQuery(_dbSet);
            if (!isTrackingEnabled) query = query.AsNoTracking();

            IEnumerable<Contact> contacts = await query.Where(c => c.Owner.Id == id).ToListAsync();
            return contacts;
        }

        public virtual async Task<IEnumerable<Contact>> GetManyPublicOnlyAsync(bool isTrackingEnabled = true)
        {
            IQueryable<Contact> query = CreateQuery(_dbSet);
            if (!isTrackingEnabled) query = query.AsNoTracking();

            IEnumerable<Contact> contacts = await query.Where(c => c.IsPublic).ToListAsync();
            return contacts;
        }

        protected override IQueryable<Contact> CreateQuery(DbSet<Contact> dbSet)
        {
            IQueryable<Contact> query = base.CreateQuery(dbSet)
                .Include(c => c.Owner)
                .Include(c => c.Category);
                //.Include(c => c.Category.ApplicableSubcategories);

            return query;
        }
    }
}
