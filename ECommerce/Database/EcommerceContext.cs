using System;
using ECommerce.Areas.Identity.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#nullable disable

namespace ECommerce.Database
{
    public class EcommerceContext : IdentityDbContext<ECommerceUser>
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ECommerceUserEntityConfiguration());
        }

        public virtual DbSet<TblCart> TblCarts { get; set; }
        public DbSet<TblCartStatus> TblCartStatuses { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblMember> TblMembers { get; set; }
        public virtual DbSet<TblMemberRole> TblMemberRoles { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblShippingDetail> TblShippingDetails { get; set; }
        public virtual DbSet<TblShippingDetail> ECommmerceUser { get; set; }

    }
}

public class ECommerceUserEntityConfiguration : IEntityTypeConfiguration<ECommerceUser>
{
    public void Configure(EntityTypeBuilder<ECommerceUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}