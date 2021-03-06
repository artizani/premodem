﻿using System;
using System.Collections.Generic;

namespace Premodem.Domain
{
    public class PremodemParts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Item { get; set; }
        public int? Type { get; set; }
        public decimal? Cost { get; set; }
        public string Description { get; set; }
        public int Expenseid { get; set; }

        public Expense Expense { get; set; }
    }
}
