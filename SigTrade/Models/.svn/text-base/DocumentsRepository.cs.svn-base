using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class DocumentsRepository: IDocumentsRepository
    {
        public int Save(Document d)
        {
            return DB.Save(d);

        }

        public  IList<ParagraphDocument> getDocumentsByID(int SourceID, int SourceType, string RoleAccess)
        {

            int i = SPs.SpGetDocumentsByID(SourceID, SourceType, RoleAccess).ExecuteTypedList<ParagraphDocument>().Count;

            if (i > 0)
                return SPs.SpGetDocumentsByID(SourceID, SourceType, RoleAccess).ExecuteTypedList<ParagraphDocument>();
            else
            {
                return null;
            }
        }

        public void DeleteDocument(int ID)
        {
            Document c = DB.Get<Document>(ID);
            c.DeletedDate = DateTime.Now;
            DB.Save(c);
            DB.Delete(c);
        }

        public Document getDocumentByID(int ID)
        {
            return DB.Get<Document>(ID);

        }
    }
}
