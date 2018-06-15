using System;
using System.Collections.Generic;

namespace Data
{
    public partial class PremodemPeople
    {
        public PremodemPeople()
        {
            PremodemExpense = new HashSet<PremodemExpense>();
            PremodemGenerator = new HashSet<PremodemGenerator>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Roles { get; set; }
        public string Email { get; set; }
        public int? MobileOne { get; set; }
        public int? MobileTwo { get; set; }
        public int? MobileThree { get; set; }
        public int? MobileFour { get; set; }
        public int? OrgId { get; set; }
        public string Bank { get; set; }
        public int? Account { get; set; }

        public ICollection<PremodemExpense> PremodemExpense { get; set; }
        public ICollection<PremodemGenerator> PremodemGenerator { get; set; }
    }
}
