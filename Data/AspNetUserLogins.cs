using System;
using System.Collections.Generic;

namespace Data
{
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }

        public AspNetUsers User { get; set; }
    }
}
