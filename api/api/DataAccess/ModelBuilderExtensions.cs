using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Business",
                },
                new Category
                {
                    Id = 2,
                    Name = "Private",
                },
                new Category
                {
                    Id = 3,
                    Name = "Other",
                }
            );

            modelBuilder.Entity<Subcategory>().HasData
            (
                new
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Boss",
                },
                new
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Manager",
                },
                new
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Co-Worker",
                },
                new
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Employee",
                },
                new
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "Family",
                },
                new
                {
                    Id = 6,
                    CategoryId = 2,
                    Name = "Friend",
                }
            );

        }
    }
}
