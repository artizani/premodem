using System;
using System.Collections.Generic;

namespace Data
{
    public partial class LoanDetails
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int? AssetId { get; set; }

        public Assets Asset { get; set; }
        public Loans Loan { get; set; }
    }
}
