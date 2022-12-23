using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerce.Database;

namespace ECommerce.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext (DbContextOptions<ECommerceContext> options)
            : base(options)
        {

        }

        public DbSet<ECommerce.Database.TblProduct> TblProduct { get; set; } = default!;
    }
}
