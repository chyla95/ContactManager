using api.DataAccess;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(DataContext dataContext) : base(dataContext) { }

        protected override IQueryable<Category> CreateQuery(DbSet<Category> dbSet)
        {
            IQueryable<Category> query = base.CreateQuery(dbSet)
                .Include(c => c.ApplicableSubcategories);
            return query;
        }
    }
}
