using System;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECommerce.Database
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCart> TblCarts { get; set; }
        public DbSet<TblCartStatus> TblCartStatuses { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblMember> TblMembers { get; set; }
        public virtual DbSet<TblMemberRole> TblMemberRoles { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblShippingDetail> TblShippingDetails { get; set; }
    }
}