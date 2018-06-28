using System;

namespace Int
{
    public class ExpenseSheet
    {
        public string Id { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string DetailedCategory { get; set; }
        public string Personnel { get; set; }
        public string AdditionalDescription { get; set; }       
        public string PaidBy { get; set; }
        public string ExpenseId { get; set; }
        public string Settled { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CategoryId { get; set; }
        public decimal ExpenseAmount { get; set; }

    }
    
    
}