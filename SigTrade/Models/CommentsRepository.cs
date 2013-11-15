using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class CommentsRepository: ICommentsRepository
    {
        public int Save(Comment c)
        {
            return DB.Save(c);
        }

        public IList<ParagraphComment> getCommentsByID(int SourceID, int SourceType,string RoleAccess)
        {

            int i = SPs.SpGetCommentsbyID(SourceID, SourceType, RoleAccess).GetDataSet().Tables[0].Rows.Count;

            if (i > 0)
                return SPs.SpGetCommentsbyID(SourceID,SourceType, RoleAccess).ExecuteTypedList<ParagraphComment>();
            else
            {
                return null;
            }

        }

        public void DeleteComment(int ID)
        {
            Comment c = DB.Get<Comment>(ID);
            c.DeletedDate = DateTime.Now;
            DB.Save(c);
            DB.Delete(c);
        }

        public Comment getCommentByID(int ID)
        {
            return DB.Get<Comment>(ID);

        }

        public int updateComment(Comment c)
        {

            return DB.Save(c);
        }


       
    }
}
