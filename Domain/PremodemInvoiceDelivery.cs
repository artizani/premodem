using System;
using System.Collections.Generic;

namespace Domain
{
    public class PremodemInvoiceDelivery
    {
        public int? Number { get; set; }
        public DateTime? Invdate { get; set; }
        public int? Storecode { get; set; }
        public int? Quantity { get; set; }
        public int? Grn { get; set; }
        public decimal? Amount { get; set; }
        public int? Supplier { get; set; }
        public string Comments { get; set; }
        public int Id { get; set; }

        public PremodemOrg SupplierNavigation { get; set; }
    }
}
