using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ContactService : Service<Contact>, IContactService
    {
        public ContactService(DataContext dataContext) : base(dataContext) { }

        protected override IQueryable<Contact> CreateQuery(DbSet<Contact> dbSet)
        {
            IQueryable<Contact> query = base.CreateQuery(dbSet);

            return query;
        }
    }
}
