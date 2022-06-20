using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgreementSystem.Areas.Identity.Data;
using AgreementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgreementSystem.Data
{
    public class AgreementSystemContext : IdentityDbContext<AgreementSystemUser>
    {
        public AgreementSystemContext(DbContextOptions<AgreementSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Product>()
           .HasIndex(b => b.Product_Number)
           .IsUnique();

            builder.Entity<ProductGroup>()
           .HasIndex(b => b.Group_Code)
           .IsUnique();

          
        }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Agreement> Agreements { get; set; }   
       
        
    }
}
