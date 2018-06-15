using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Loans
    {
        public Loans()
        {
            LoanDetails = new HashSet<LoanDetails>();
        }

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Status { get; set; }

        public ProfileInfoes IdNavigation { get; set; }
        public ICollection<LoanDetails> LoanDetails { get; set; }
    }
}
