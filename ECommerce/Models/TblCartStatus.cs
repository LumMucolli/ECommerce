using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ECommerce.Models
{
    public partial class TblCartStatus
    {
        [Key]
        public int CartStatusId { get; set; }
        [Required]
        public string CartStatus { get; set; }
    }
}
