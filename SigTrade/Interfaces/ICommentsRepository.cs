using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Interfaces
{
    public interface ICommentsRepository
    {
        int Save(Comment c);
        IList<ParagraphComment> getCommentsByID(int SourceID, int SourceType, string RoleAccess);
        void DeleteComment(int ID);

        Comment getCommentByID(int ID);
        int updateComment(Comment c);
    }
}
