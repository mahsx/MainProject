using batch3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace batch3.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
      
            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                Name = "Company1",
                Address = "123 Main St",
                City = "New York",
                State = "NY",
                PostalCode = "10000",
                PhoneNumber = "123-456-7890"
            },
            new Company
            {
                CompanyId = 2,
                Name = "Company2",
                Address = "123 Main St",
                City = "New York",
                State = "NY",
                PostalCode = "10000",
                PhoneNumber = "123-456-7890"
            });

        }
    }


}