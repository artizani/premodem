using System;
using System.Collections.Generic;

namespace Data
{
    public partial class PremodemExpense
    {
        public PremodemExpense()
        {
            PremodemEnergy = new HashSet<PremodemEnergy>();
            PremodemParts = new HashSet<PremodemParts>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public int? Item { get; set; }
        public int Personnel { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Labour { get; set; }
        public string Paidfrom { get; set; }
        public int? SettledDate { get; set; }

        public PremodemExpenseCategory ItemNavigation { get; set; }
        public PremodemPeople PersonnelNavigation { get; set; }
        public ICollection<PremodemEnergy> PremodemEnergy { get; set; }
        public ICollection<PremodemParts> PremodemParts { get; set; }
    }
}
