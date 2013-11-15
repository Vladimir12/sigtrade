using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigTrade.Models
{
    public class Taxons
    {
        public int genrecid { get; set; }
        public string genname { get; set; }
        public int spcrecid { get; set; }
        public string spcname { get; set; }
    }
}
