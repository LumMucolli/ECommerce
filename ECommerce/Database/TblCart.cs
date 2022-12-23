using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ECommerce.Database
{
    public partial class TblCart
    {
        [Key]
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? MemberId { get; set; }
        public int? CartStatusId { get; set; }

        public virtual TblProduct Product { get; set; }
    }
}
