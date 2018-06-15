using System;
using System.Collections.Generic;

namespace Data
{
    public partial class AspNetUserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public AspNetRoles Role { get; set; }
        public AspNetUsers User { get; set; }
    }
}
