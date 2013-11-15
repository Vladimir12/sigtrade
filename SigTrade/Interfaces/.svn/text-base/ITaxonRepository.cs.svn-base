using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Interfaces
{
    public interface ITaxonRepository
    {
       
        //IList<AKingdom> getKingdom();
        IList<GeneralLib> getKingdom();
        IList<AGeneralTaxon> getAPhylum();
        IList<AGeneralTaxon> getAClass();
        IList<AGeneralTaxon> getAOrder();
        IList<AGeneralTaxon> getAFamily();
        IList<AGeneralTaxon> getAGenus();
        IList<AGeneralTaxon> getASpecies();
        IList<AGeneralTaxon> getASpeciesbyGenus(int genusID);

        IList<AGeneralTaxon> getPFamily();
        IList<AGeneralTaxon> getPGenus();
        IList<AGeneralTaxon> getPSpecies();
        IList<AGeneralTaxon> getPSpeciesbyGenus(int genusID);
        IList<AGeneralTaxon> getCountries(int TaxonID, string TaxonType, string Kingdom);

        IList<AGeneralTaxon> getPSpeciesbyGenusSearch(int genusID);
        IList<AGeneralTaxon> getASpeciesbyGenusSearch(int genusID);
        IList<AGeneralTaxon> getPGenusSearch();
        IList<AGeneralTaxon> getAGenusSearch();
        IList<AGeneralTaxon> getASpeciesSearch();
        IList<AGeneralTaxon> getPSpeciesSearch();
        IList<AGeneralTaxon> getCountriesSearch(int TaxonID, string TaxonType, string Kingdom);


        IList<SelectItems> getReportCountries();
        IList<SelectItems> getReportParagraphActions();
        IList<SelectItems> getReportSpecies();

        Taxons getTaxonbySpecies(int SpeciesID, int Kingdom);

        string getParagraphStagePerReview(int ReviewID);
        DateTime getDeadlineDatePerReview(int ReviewID);

        IList<ReviewDesc> getAllReviews();

        IList<ReviewDesc> GetAllReviewsPaged(int pageIndex, int pageSize);

        string getReviewTaxonName(int TaxonID, string TaxonType, string Kingdom);

        int getTaxonLevelID(string taxonlevel);

        void deleteReview(TblReview r);

        TblReview getReview(int id);

        int SaveReview(TblReview r);

    }
}
