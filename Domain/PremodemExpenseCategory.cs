using System;
using System.Collections.Generic;

namespace Domain
{
    public class PremodemExpenseCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int? PartId { get; set; }
        public int? CatId { get; set; }
        public string Description { get; set; }
        public int? EnergyId { get; set; }

        public PremodemExpense PremodemExpense { get; set; }
    }
}
