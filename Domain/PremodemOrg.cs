using System;
using System.Collections.Generic;

namespace Premodem.Domain
{
    public partial class PremodemOrg
    {
        public PremodemOrg()
        {
            PremodemDeliveryrate = new HashSet<PremodemDeliveryrate>();
            PremodemInvoiceDelivery = new HashSet<PremodemInvoiceDelivery>();
        }

        public string Orgname { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int Id { get; set; }
        public int? Accountnumber { get; set; }
        public string Bank { get; set; }
        public string Description { get; set; }

        public ICollection<PremodemDeliveryrate> PremodemDeliveryrate { get; set; }
        public ICollection<PremodemInvoiceDelivery> PremodemInvoiceDelivery { get; set; }
    }
}
