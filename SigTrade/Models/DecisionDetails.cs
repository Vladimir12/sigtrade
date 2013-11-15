using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigTrade.Models {
    public class DecisionDetails {
        public int DecisionId { get; set; }
        public string DecisionType { get; set; }
        public string TradeTerms { get; set; }
       // public string DecisionCommittee { get; set; }
       // public string LiftingComittee { get; set; }
        public DateTime DecisionDate { get; set; }
        public DateTime LiftingDate { get; set; }

    }
}
