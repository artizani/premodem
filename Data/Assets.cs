using System;
using System.Collections.Generic;

namespace Data
{
    public partial class Assets
    {
        public Assets()
        {
            LoanDetails = new HashSet<LoanDetails>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Multiple { get; set; }
        public int Count { get; set; }
        public int AssetType { get; set; }
        public string Speaker { get; set; }
        public string Isbn { get; set; }
        public string Presenter { get; set; }
        public string Discriminator { get; set; }

        public ICollection<LoanDetails> LoanDetails { get; set; }
    }
}
