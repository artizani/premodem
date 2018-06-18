using System;
using System.Collections.Generic;

namespace Domain
{
    public class PremodemGenerator
    {
        public int Id { get; set; }
        public decimal? Slacktime { get; set; }
        public string Channel { get; set; }
        public int? User { get; set; }
        public DateTime? DateTime { get; set; }
        public decimal Counter { get; set; }

        public PremodemPeople UserNavigation { get; set; }
    }
}
