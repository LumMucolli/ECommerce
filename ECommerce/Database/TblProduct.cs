using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ECommerce.Database
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblCarts = new HashSet<TblCart>();
        }
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? Description { get; set; }
        public string ProductImage { get; set; }
        public bool? IsFeatured { get; set; }
        public int? Quantity { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual ICollection<TblCart> TblCarts { get; set; }
    }
}
