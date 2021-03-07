using E_CommerceApi.Models.dbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApi.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.dbModels.Attribute> Attributes { get; set; }
        public DbSet<AttributeType> AttributeTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandImage> BrandImages { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<CartMain> CartMain { get; set; }
        public DbSet<CategoryImage> CategoryImages { get; set; }
        public DbSet<CategoryMain> CategoryMain { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductMain> ProductMain { get; set; }
        public DbSet<ShippingProfile> ShippingProfiles { get; set; }
        //public DbSet<Attribute> Attributes { get; set; }
    }
}
