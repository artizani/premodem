﻿using System;
using System.Collections.Generic;

namespace Premodem.Domain
{
    public class PremodemEnergy
    {
        public int Id { get; set; }
        public int? Item { get; set; }
        public decimal? Rate { get; set; }
        public int? Unit { get; set; }
        public int? Quantity { get; set; }
        public int? ExpenseId { get; set; }
        public int? SupplierId { get; set; }

        public Expense Expense { get; set; }
    }
}
