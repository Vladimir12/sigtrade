using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;
using SubSonic;

namespace SigTrade.Models
{
    public class TaxonRepository: ITaxonRepository
    {
     
        public IList<GeneralLib> getKingdom()
        {
            //return DB.Select().From<AKingdom>().ExecuteTypedList<AKingdom>();
            return
                DB.Select().From<GeneralLib>().Where(GeneralLib.TypeColumn).Like("kingdom").ExecuteTypedList<GeneralLib>();

        }

        public IList<AGeneralTaxon> getAPhylum()
        {
            return SPs.GetAPhylumList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getAClass()
        {
            return SPs.GetAClassList().ExecuteTypedList<AGeneralTaxon>();
        }
        public IList<AGeneralTaxon> getAOrder()
        {
            return SPs.SpGetAOrderList().ExecuteTypedList<AGeneralTaxon>();
        }
        public IList<AGeneralTaxon> getAFamily()
        {
            return SPs.GetAFamilyList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getAGenus()
        {

            return SPs.GetAGenusList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getAGenusSearch()
        {

            return SPs.SpGetAGenusSearch().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getASpecies()
        {
            return SPs.GetASpeciesList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getPFamily()
        {
            return SPs.GetPFamilyList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getPGenus()
        {

            return SPs.GetPGenusList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getPGenusSearch()
        {

            return SPs.SpGetPGenusListSearch().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getPSpecies()
        {
            return SPs.GetPSpeciesList().ExecuteTypedList<AGeneralTaxon>();
        }

        public IList<AGeneralTaxon> getASpeciesSearch()
        {
            return SPs.GetASpeciesListSearch().ExecuteTypedList<AGeneralTaxon>();

        }
        public IList<AGeneralTaxon> getPSpeciesSearch()
        {
            return SPs.GetPSpeciesListSearch().ExecuteTypedList<AGeneralTaxon>();

        }

        public IList<AGeneralTaxon> getPSpeciesbyGenusSearch(int genusID)
        {

            return SPs.SpGetPSpeciesByGenusSearch(genusID).ExecuteTypedList<AGeneralTaxon>();

        }

        public IList<AGeneralTaxon> getPSpeciesbyGenus(int genusID)
        {

            return SPs.SpGetPSpeciesbyGenusList(genusID).ExecuteTypedList<AGeneralTaxon>();

        }

        public IList<AGeneralTaxon> getASpeciesbyGenusSearch(int genusID)
        {

            return SPs.SpGetASpeciesByGenusSearch(genusID).ExecuteTypedList<AGeneralTaxon>();

        }

        public IList<AGeneralTaxon> getASpeciesbyGenus(int genusID)
        {

                return SPs.SpGetASpeciesbyGenusList(genusID).ExecuteTypedList<AGeneralTaxon>();

        }

        public IList<AGeneralTaxon> getCountries(int TaxonID, string TaxonType, string Kingdom)
        {
            return SPs.GetCountriesbyTaxon(TaxonID, TaxonType, Kingdom).ExecuteTypedList<AGeneralTaxon>();

        }

        public IList<AGeneralTaxon> getCountriesSearch(int TaxonID, string TaxonType, string Kingdom)
        {
            if (Kingdom == UpdateUtils.ALL_KINGDOM)
                return DB.Select().From("VwDistribCty").OrderAsc("TaxonName").ExecuteTypedList<AGeneralTaxon>();
            
            return SPs.GetCountriesByTaxonSearch(TaxonID, TaxonType, Kingdom).ExecuteTypedList<AGeneralTaxon>();

        }

        public int SaveReview (TblReview r)
        {

            return DB.Save(r);

        }

        public int getTaxonLevelID(string taxonname)
        {

           GeneralLib g = 
                DB.Select("ExternalRef").From<GeneralLib>().Where(GeneralLib.DescriptionColumn).Like(taxonname).ExecuteSingle<GeneralLib>();

            return int.Parse(g.ExternalRef);
        
        }

        public IList<ReviewDesc> getAllReviews()
        {

            return SPs.GetTaxonSelected2().ExecuteTypedList<ReviewDesc>();
        }

        public IList<ReviewDesc> GetAllReviewsPaged(int pageIndex, int pageSize)
        {
            SqlQuery q = Select.AllColumnsFrom<VwAllReview>().OrderDesc("ReviewDate","PhaseStartDate","DeadlineDate").Paged(pageIndex, pageSize);
            int count = q.GetRecordCount();
            return q.ExecuteTypedList<ReviewDesc>();
      
            throw new NotImplementedException();
        }

        public string getReviewTaxonName(int TaxonID, string TaxonType, string Kingdom)
        {
           // return SPs.GetTaxonSelected(TaxonID, TaxonType, Kingdom).GetDataSet().Tables[0].Rows[0][0].ToString();
            return SPs.GetTaxonSelected(TaxonID, TaxonType, Kingdom).GetDataSet().Tables[0].Rows[0]["TaxonName"].ToString();
            
        }

        public string getParagraphStagePerReview(int ReviewID)
        {

            DataRowCollection rows = SPs.SpGetParagraphStagePerReview(ReviewID).GetDataSet().Tables[0].Rows;

            if (rows.Count > 0)
                return rows[0][0].ToString();
            else
            {
                return UpdateUtils.NO_PARAGRAPH;
            }
            /*
            if(SPs.SpGetParagraphStagePerReview(ReviewID).GetDataSet().Tables[0].Rows.Count >0)
            {
                return SPs.SpGetParagraphStagePerReview(ReviewID).ExecuteScalar().ToString();
            }
            else
            {
                return UpdateUtils.NO_PARAGRAPH;
            }*/

        }

        public DateTime getDeadlineDatePerReview(int ReviewID)
        {
            DataRowCollection rows = SPs.SpGetDeadlineForReview(ReviewID).GetDataSet().Tables[0].Rows;

            if (rows.Count > 0)
                return DateTime.Parse(rows[0][0].ToString());
            else
                return DateTime.Parse("01/01/1901");

            if (SPs.SpGetDeadlineForReview(ReviewID).GetDataSet().Tables[0].Rows.Count > 0)
            {
                return (DateTime)SPs.SpGetDeadlineForReview(ReviewID).ExecuteScalar();
            }
            else
            {
                return DateTime.Parse("01/01/1901");
            }

        }

        //public  int deleteReview(int id)
        //{

        //    return DB.Delete().From<Review>().Where(Review.IdColumn).IsEqualTo(id).Execute();

        //}

        public  void deleteReview(TblReview r)
        {
           r.DeletedDate = DateTime.Now;
           IReviewRepository reviews = new ReviewRepository();
            int reviewID = r.Id;

            var paragraphs = reviews.getParagraphActionByReview(reviewID);
            foreach (var paragraphAction in paragraphs)
            {
                DB.Delete(paragraphAction);
            }

           DB.Save(r);
           DB.Delete(r);

        }

        public IList<SelectItems> getReportSpecies()
        {
            throw new NotImplementedException();
        }

        public Taxons getTaxonbySpecies(int SpeciesID, int Kingdom)
         {
             return (Taxons)SPs.SpGetTaxonsBySpecies(SpeciesID, Kingdom).ExecuteTypedList<Taxons>().First();

         }


        public TblReview getReview(int id)
        {
            return DB.Select().From<TblReview>().Where(TblReview.IdColumn).IsEqualTo(id).ExecuteSingle<TblReview>();

        }



        public IList<SelectItems> getReportCountries() {
            return SPs.SpReportGetCountries().ExecuteTypedList<SelectItems>();
        }


        public IList<SelectItems> getReportParagraphActions() {
            return SPs.SpReportParagraphActions().ExecuteTypedList<SelectItems>();
        }

      
    }
}
