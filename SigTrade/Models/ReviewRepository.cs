using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;

namespace SigTrade.Models
{
    public class ReviewRepository: IReviewRepository
    {
        public int getReviewStatusID(string review)
        {
            return 1;
         

        }

        public void saveReviewStatus(ReviewStatus r)
        {
            DB.Save(r);

        }

        public ReviewDesc getSingleReview(int? ID)
        {
            if (SPs.SpGetSingleReview(ID).GetDataSet().Tables[0].Rows.Count >0 )
                return SPs.SpGetSingleReview(ID).ExecuteTypedList<ReviewDesc>()[0];
            else
            {
                return null;
            }

        }

        public TblReview getSingleReviewEdit(int? ID)
        {
            return DB.Get<TblReview>(ID);

        }


        public IList<ParagraphActionLib> getAllPALib()
        {

            return DB.Select().From<ParagraphActionLib>().ExecuteTypedList<ParagraphActionLib>();
            
        }



        public ParagraphActionLib getSinglePALib(int? ID)
        {

            return DB.Select().From<ParagraphActionLib>().Where(ParagraphActionLib.IdColumn).IsEqualTo(ID).ExecuteTypedList<ParagraphActionLib>()[0];
        }



        public ParagraphActionDetails getParagraphDetails(int PALibID, int ReviewID)
        {

            int i = SPs.GetParagraphActionDetails(PALibID, ReviewID).GetDataSet().Tables[0].Rows.Count;
            if (i > 0)
              return SPs.GetParagraphActionDetails(PALibID, ReviewID).ExecuteTypedList<ParagraphActionDetails>()[0];
               
            else
            {
                return null;
            }
        }

        public IList<PALibExtra> getAllPALibExtra(int ReviewID)
        {
            if (SPs.GetAllPALibExtra(ReviewID).GetDataSet().Tables[0].Rows.Count > 0)
                return SPs.GetAllPALibExtra(ReviewID).ExecuteTypedList<PALibExtra>();
            else
            {
                return null;
            }

        }

        public int getNextParagraphForReview(int ReviewID)
        {
            return int.Parse(SPs.SpGetNextParagraphDetails(ReviewID).GetDataSet().Tables[0].Rows[0]["ID"].ToString());
        }

        public int SavePA(ParagraphAction pa)
        {
            return DB.Save(pa);
        }

        public ParagraphAction getParagraphActionbyID(int PActionID)
        {
            return DB.Get<ParagraphAction>(PActionID);

        }

        public IList<ReviewDesc> getAllReviewsbyFreeSearch(string Genus, string Species)

        {
            if (SPs.GetAllReviewsByFreeSearch(Genus, Species).GetDataSet().Tables[0].Rows.Count >0)
                 return SPs.GetAllReviewsByFreeSearch(Genus, Species).ExecuteTypedList<ReviewDesc>();
            else
            {
                return null;
            }
        }
        public IList<ReviewDesc> getAllReviewsbyCountry(int CountryID)
        {
            if (SPs.GetAllReviewsByCountry(CountryID).GetDataSet().Tables[0].Rows.Count > 0)
               return SPs.GetAllReviewsByCountry(CountryID).ExecuteTypedList<ReviewDesc>();
            else
            {
                return null;
            }
        }

        public IList<ReviewDesc> getAllReviewsbySearchAll(int PhaseID, string Kingdom, int GenusID, int SpeciesID, int CountryID)
        {
            if (SPs.GetAllReviewsBySearchAll(PhaseID,Kingdom,GenusID,SpeciesID,CountryID).GetDataSet().Tables[0].Rows.Count>0)
            return
                SPs.GetAllReviewsBySearchAll(PhaseID, Kingdom, GenusID, SpeciesID, CountryID).ExecuteTypedList
                    <ReviewDesc>();
            else
            {
                return null;
            }
           
        }

        public string getConcernForReview(int ReviewID)
        {
            int concernid = 0;
            string concern = null;
            //if (DB.Select(ParagraphAction.ConcernIDColumn.DisplayName).From<ParagraphAction>().Where(
            //        ParagraphAction.ReviewIDColumn).IsEqualTo(ReviewID).And(ParagraphAction.CurrentConcernColumn).
            //        IsEqualTo(true).ExecuteDataSet().Tables[0].Rows.Count > 0)
            //{
            //    concernid =
            //        int.Parse(DB.Select(ParagraphAction.ConcernIDColumn.DisplayName).From<ParagraphAction>().Where(
            //                      ParagraphAction.ReviewIDColumn).IsEqualTo(ReviewID).And(
            //                      ParagraphAction.CurrentConcernColumn).
            //                      IsEqualTo(true).ExecuteScalar().ToString());
            //}

            //get the concern from the review table
            if (DB.Select("ConcernID").From<TblReview>().Where(
                   TblReview.IdColumn).IsEqualTo(ReviewID).And(TblReview.ConcernIDColumn).IsNotNull().ExecuteDataSet().Tables[0].Rows.Count > 0)
            {
                concernid =
                    int.Parse(DB.Select("ConcernID").From<TblReview>().Where(
                        TblReview.IdColumn).IsEqualTo(ReviewID).ExecuteScalar().ToString());
            }

            switch (concernid)
            {
                case UpdateUtils.URGENT_CONCERN_ID:
                    concern = UpdateUtils.URGENT_CONCERN;
                    break;
                case UpdateUtils.POSSIBLE_CONCERN_ID:
                    concern = UpdateUtils.POSSIBLE_CONCERN;
                    break;
                case UpdateUtils.LEAST_CONCERN_ID:
                    concern = UpdateUtils.LEAST_CONCERN;
                    break;
                case UpdateUtils.NOT_CLASSIFIED_ID:
                    concern = UpdateUtils.NOT_CLASSIFIED;
                    break;
                default:
                    concern = UpdateUtils.NOT_CLASSIFIED;
                    break;
            }
            return concern;
        }




        public IList<ParagraphAction> getParagraphActionByReview(int ReviewId) {
            return
                DB.SelectAllColumnsFrom<ParagraphAction>().Where("ReviewID").IsEqualTo(ReviewId).ExecuteTypedList
                    <ParagraphAction>();

            throw new NotImplementedException();
        }
    }
}
