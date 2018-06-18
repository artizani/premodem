using System;
using System.Collections.Generic;

namespace Premodem.Domain
{
    public class PremodemDeliveryrate
    {
        public int? StoreId { get; set; }
        public int Id { get; set; }
        public decimal? Rate { get; set; }
        public int? Supplier { get; set; }
        public bool? Active { get; set; }

        public PremodemOrg SupplierNavigation { get; set; }
    }
}
