using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Database
{
    public partial class TblShippingDetail
    {
        public int ShippingDetailId { get; set; }
        public int? MemberId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? OrderId { get; set; }
        public decimal? AmountPaid { get; set; }
        public string PaymentType { get; set; }

        public virtual TblMember Member { get; set; }
    }
}
