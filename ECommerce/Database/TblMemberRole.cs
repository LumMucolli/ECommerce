using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ECommerce.Database
{
    public partial class TblMemberRole
    {
        [Key]
        public int MemberRoleId { get; set; }
        public int? MemberId { get; set; }
        public int? RoleId { get; set; }
    }
}
