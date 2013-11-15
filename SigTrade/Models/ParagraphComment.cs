using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SigTrade.Models
{
    /// <summary>
    //Accessor class for a comment - this contains all the data the will need to be output for a comment.
    /// </summary>
    public class ParagraphComment
    {
        public int ID { get; set;}
        public string Comments { get; set; }
        public DateTime DateAdded { get; set; }
        public string RoleAccess { get; set; }
        public string UserID { get; set; }
        public string SourceType { get; set; }
        public int SourceID { get; set; }
    }
}
