using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigTrade.Models
{
    public class ParagraphActionDetails
    {
        public int ID { get; set; }
        public int PALibID  {get; set;}
        public DateTime DateStarted { get; set; }
        public DateTime Deadline { get; set; }
        public int CommitteeID { get; set; }
        public string CommitteeDesc { get; set; }
        public int MeetingID { get; set; }
        public string MeetingLibDesc { get; set; }
        public int ReviewID { get; set; }
        public bool Completed { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
