using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ECommerce.Database
{
    public partial class TblRole
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
