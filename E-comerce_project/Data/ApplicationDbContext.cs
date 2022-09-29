using E_comerce_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_comerce_project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<ProductImages> ProductImages  { get; set; }

        public DbSet<ShopingCart> ShoppingCarts { get; set; }   
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Newsletter> Newsletter { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<SocieteInfos> SocieteInfos { get; set; }
        public DbSet<specification> Specifications { get; set; }


    }
}
