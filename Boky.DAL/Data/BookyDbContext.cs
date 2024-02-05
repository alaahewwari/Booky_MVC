using Booky.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.DAL.Data
{
    public class BookyDbContext : DbContext
    {
        public BookyDbContext(DbContextOptions<BookyDbContext> options) : base(options) //options contain connection string
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Programming",DisplayOrder= 2 },
                new Category { Id = 2, Name = "Databases",DisplayOrder= 1 },
                new Category { Id = 3, Name = "Web Development",DisplayOrder= 3 }
                );
        }
        public DbSet<Category> Categories { get; set; }
    }
}
