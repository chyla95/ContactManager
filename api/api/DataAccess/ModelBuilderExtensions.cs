using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Subcategory subcategoryBoss = new()
            {
                Id = 1,
                Name = "Boss"
            };
            Subcategory subcategoryLeader = new()
            {
                Id = 2,
                Name = "Leader"
            };
            Subcategory subcategoryCoWorker = new()
            {
                Id = 3,
                Name = "Co-Worker"
            };
            Subcategory subcategoryEmployee = new()
            {
                Id = 4,
                Name = "Employee"
            };


            Category categoryBusiness = new()
            {
                Id = 1,
                Name = "Private",
                ApplicableSubcategories = new List<Subcategory>()
                {
                    subcategoryBoss,
                    subcategoryLeader,
                    subcategoryCoWorker,
                    subcategoryEmployee
                }
            };

            Category categoryPrivate = new()
            {
                Id = 2,
                Name = "Private",
            };

            modelBuilder.Entity<Category>().HasData
            (
                categoryBusiness,
                categoryPrivate
            );
        }
    }
}
