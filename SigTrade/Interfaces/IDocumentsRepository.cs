using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Interfaces
{
    public interface IDocumentsRepository
    {
        int Save(Document d);

        IList<ParagraphDocument> getDocumentsByID(int SourceID, int SourceType, string RoleAccess);
        void DeleteDocument(int ID);

        Document getDocumentByID(int ID);

    }
}
