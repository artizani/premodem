using System;
using System.Collections.Generic;

namespace Data
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
