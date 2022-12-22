using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Database
{
    public partial class TblCart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? MemberId { get; set; }
        public int? CartStatusId { get; set; }

        public virtual TblProduct Product { get; set; }
    }
}
