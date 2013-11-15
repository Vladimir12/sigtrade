using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Interfaces
{
    public interface IReviewRepository
    {
        int getReviewStatusID(string status);

        void saveReviewStatus(ReviewStatus r);
        ReviewDesc getSingleReview(int? ID);
        TblReview getSingleReviewEdit(int? ID);

        IList<ParagraphActionLib> getAllPALib();
        ParagraphActionLib getSinglePALib(int? ID);
        ParagraphActionDetails getParagraphDetails(int PALibID, int ReviewID);
        IList<PALibExtra> getAllPALibExtra(int ReviewID);

        IList<ParagraphAction> getParagraphActionByReview(int ReviewId);

        int getNextParagraphForReview(int ReviewID);

        ParagraphAction getParagraphActionbyID(int PActionID);
        IList<ReviewDesc> getAllReviewsbyFreeSearch(string Genus, string Species);
        IList<ReviewDesc> getAllReviewsbyCountry(int CountryID);
        IList<ReviewDesc> getAllReviewsbySearchAll(int PhaseID, string Kingdom, int GenusID, int SpeciesID, int CountryID);
        

        int SavePA(ParagraphAction pa);

        string getConcernForReview(int ReviewID);
    }
}
