using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using SignificantTrade.Models;
using SigTrade.Interfaces;
using SigTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Paging;
using SubSonic;
using TblReview=SignificantTradeSSRepository.TblReview;


namespace SigTrade.Controllers
{
    public class AddReviewController : Controller
    {
        //
        // GET: /AddReview/

        public ActionResult ReviewIndex()
        {
            ITaxonRepository Taxon = new TaxonRepository();
            IGenericRepository gen = new GenericRepository();

            ViewData["Phase"] = gen.getAllPhase();
            ViewData["Kingdom"] = Taxon.getKingdom();

            return View();
        }


        // GET: /AddReview/

        public ActionResult List(int? page)
        {
           
            ViewData["AllReviews"] = this.GetAllReviews(page);
            return View();  
        }

        //POST: /AddReview/ListAll
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ListAll(FormCollection collection,int? page)
        {
            Session["search_form"] = collection;
            return RedirectToAction("ListAll",new{page =1});

        }

        //GET: /AddReview/ListAll
        public ActionResult ListAll(int? page, int? searched)
        {
           

            if (page.HasValue) {
                //return RedirectToAction("ListAll", new { collection = (FormCollection)Session["search_form"], page = page, searched = 1 });

                ITaxonRepository RPtaxons = new TaxonRepository();
                IReviewRepository RPreviews = new ReviewRepository();

                string freesearch, searchcountry, searchall = "";

                FormCollection collection = (FormCollection)Session["search_form"];

                try {
                    //freesearch = collection["search1"];
                    freesearch = collection["search_free"];
                    searchcountry = collection["search2"];
                    searchall = collection["search3"];

                    IList<ReviewDesc> reviews = null;
                    IList<ReviewDesc> reviews2 = null;

                    //return reviews;

                    string nodata = "No search results found";
                    if (freesearch != null) {
                        var search = collection["searchspecies"];
                        if (search.IndexOf('-') == -1)
                            return RedirectToAction("Search", "SearchReview");
                        string searchstring = collection["searchspecies"];
                        searchstring = searchstring.Trim();
                        string[] splitstring = searchstring.Split('-');

                        //Have changed coding now - the genus species is returned, so need to split further to keep same method
                        string[] taxonString = splitstring[0].Split(' ');
 
                        reviews = RPreviews.getAllReviewsbyFreeSearch(taxonString[0].Trim(), taxonString[1].Trim());
                    }
                    else if (searchcountry != null) {
                        string countryID = collection["searchcountry"];
                        if (countryID.ToUpper().Contains(UpdateUtils.SELECT_ALL)) {
                            reviews = this.GetAllReviews(null);

                        }
                        else {
                            int country = int.Parse(countryID);
                            reviews = RPreviews.getAllReviewsbyCountry(country);
                        }

                    }
                    else if (searchall != null) {
                        int phase = int.Parse(collection["phase"]);
                        string kingdom = collection["kingdom"];
                        //-2 is for select all
                        int genus = -2;
                        int species = -2;
                        int country = -2;

                        if (collection["agenus"] != null)
                            genus = int.Parse(collection["agenus"]);
                        if (collection["aspecies"] != null)
                            species = int.Parse(collection["aspecies"]);
                        if (collection["acountries"] != null) {
                            country = int.Parse(collection["acountries"]);
                        }

                        if (kingdom.Equals(UpdateUtils.ALL_KINGDOM.ToString())) {
                            IList<ReviewDesc> reviewstemp = RPreviews.getAllReviewsbySearchAll(phase, UpdateUtils.ANIMALS, genus, species, country);
                            reviews2 = RPreviews.getAllReviewsbySearchAll(phase, UpdateUtils.PLANTS, genus, species, country);

                            if (reviewstemp != null && reviews2 != null)
                                reviews = reviewstemp.Concat(reviews2).ToList();

                            if (reviewstemp == null && reviews2 != null)
                                reviews = reviews2;

                            if (reviewstemp != null && reviews2 == null)
                                reviews = reviewstemp;
                            else {
                                reviews = null;
                            }

                        }

                        else {
                            reviews = RPreviews.getAllReviewsbySearchAll(phase, kingdom, genus, species, country);
                        }

                    }

                    int count = 0;
                    if (reviews != null)
                        count = reviews.Count;

                    if (count > 0) {
                        for (int i = 0; i < count; i++) {

                            //        reviews[i].TaxonName = RPtaxons.getReviewTaxonName(reviews[i].TaxonID, reviews[i].Taxontype,
                            //                                                        reviews[i].Kingdom);
                            reviews[i].Paragraph = RPtaxons.getParagraphStagePerReview(reviews[i].ID);
                            reviews[i].Concern = RPreviews.getConcernForReview(reviews[i].ID);
                            reviews[i].DeadlineDate = RPtaxons.getDeadlineDatePerReview(reviews[i].ID);
                        }

                    }

                    int ij = 10;
                    if (reviews == null) {

                        return RedirectToAction("Search", "SearchReview", new { NoSearchResults = true });
                    }
                    var sortedReviews = from r in reviews
                                        orderby r.DateAdded
                                        select r;
                    //PageIndex
                    int PageIndex = 0;
                    if (page.HasValue)
                        PageIndex = (int)page;

                    IPagedList<ReviewDesc> pagedReview = sortedReviews.ToPagedList(PageIndex, UpdateUtils.DEFAULT_PAGE_SIZE);

                    ViewData["AllReviews"] = pagedReview;//sortedReviews.ToPagedList(1,count);
                    ViewData["PageSize"] = UpdateUtils.DEFAULT_PAGE_SIZE;
                    ViewData["PageNumber"] = PageIndex;
                    ViewData["TotalItemCount"] = count;
                    return View();
                }
                catch {
                    return RedirectToAction("Search", "SearchReview");
                }
            
            }

            ViewData["AllReviews"] = this.GetAllReviews(page);

            return View();

        }


        //
        // POST: /AddReview/SearchList

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SearchList(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
               

                return View();
            }
            catch
            {
                return View();
            }
        }

       
        private void saveSpeciesForReview()
        {
            ITaxonRepository Taxon = new TaxonRepository();
            IGenericRepository gen = new GenericRepository();
            IReviewRepository rr = new ReviewRepository();

            if (TempData["CurrentData"] != null)
            {
                DataTable dt = (DataTable)TempData["CurrentData"];
                int rowcount = dt.Rows.Count;
                ITaxonRepository taxon = new TaxonRepository();
                for (int i = 0; i < rowcount; i++)
                {
                    DataRow dr = dt.Rows[i];

                    TblReview r = new TblReview();


                    r.PhaseID = int.Parse(dr[1].ToString());
                    r.KingdomID = taxon.getTaxonLevelID(dr[7].ToString());
                    r.TaxonLevel = taxon.getTaxonLevelID(dr[2].ToString());
                    r.TaxonID = int.Parse(dr[4].ToString());
                    r.DateAdded = DateTime.Now;
                    r.CountryID = int.Parse(dr[6].ToString());

                    int ID = taxon.SaveReview(r);


                    ReviewStatus rs = new ReviewStatus();
                    rs.Status = gen.getExternalRef(UpdateUtils.SELECTION, UpdateUtils.REVIEWSTATUS);
                    rs.DateAdded = DateTime.Now;
                    rs.ReviewID = ID;
                    rr.saveReviewStatus(rs);

                }
            } 

        }




        private  IList<ReviewDesc> GetAllReviews(int? pageIndex)
        {
            ITaxonRepository Taxon = new TaxonRepository();
            IReviewRepository reviews = new ReviewRepository();
           // IList<ReviewDesc> review = Taxon.GetAllReviews();

            int currentIndex = (int) (pageIndex ?? 1);
           
            //int count = review.Count;
           // int count = Taxon.getAllReviews().Count;
            SqlQuery query = Select.AllColumnsFrom<VwAllReview>();
            int count = query.GetRecordCount();
            ViewData["TotalItemCount"] = count;
            ViewData["PageNumber"] = currentIndex;
            ViewData["PageSize"] = UpdateUtils.DEFAULT_PAGE_SIZE;
            
            IList<ReviewDesc> review = Taxon.GetAllReviewsPaged(currentIndex, UpdateUtils.DEFAULT_PAGE_SIZE);

            var sortedReviews = from r in review
                                orderby r.CtyShort
                                select r;

            int pagedCount = review.Count;

            if ( pagedCount > 0)
            {
                for (int i = 0; i < pagedCount; i++)
                {
                    review[i].TaxonName = Taxon.getReviewTaxonName(review[i].ID, review[i].Taxontype,
                                                                    review[i].Kingdom);

                    review[i].Paragraph = Taxon.getParagraphStagePerReview(review[i].ID);

                    review[i].Concern = reviews.getConcernForReview(review[i].ID);
                    review[i].DeadlineDate = Taxon.getDeadlineDatePerReview(review[i].ID);

                }
            }

            if (pagedCount <= 0)
                review = null;
            return review;

        }

        //
        // GET: /AddReview/Delete/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("List", "AddReview");
        }


        //PUT : /AddReview/Delete
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(FormCollection collection)
        {
            ITaxonRepository Taxon = new TaxonRepository();

            var reviewID = Int32.Parse(collection["ID"]);

            TblReview r = Taxon.getReview(reviewID);

            Taxon.deleteReview(r);

           return RedirectToAction("Delete");
        }
        //
        // GET: /AddReview/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AddReview/AddCountries

        public ActionResult GetCountries(bool ajax, string speciesID, string kingdom)
        {
            IGenericRepository gen = new GenericRepository();

            ITaxonRepository taxon = new TaxonRepository();

            IList<AGeneralTaxon> lists = null;
            int _speciesID = int.Parse((speciesID));

            if (kingdom.Equals("animal"))
            {
                lists = taxon.getCountries(_speciesID, UpdateUtils.SPECIES, UpdateUtils.ANIMALS);
            }
            else if (kingdom.Equals("plant"))
            {
                lists = taxon.getCountries(_speciesID, UpdateUtils.SPECIES, UpdateUtils.PLANTS);
            }
           
           // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);

        }

        // GET: /AddReview/GetGenus
        public ActionResult GetGenus(bool ajax, string value)
        {
            IGenericRepository gen = new GenericRepository();
            ITaxonRepository taxon = new TaxonRepository();

            IList<AGeneralTaxon> lists = null;

        if (value.Equals("animal"))
            {
               lists = taxon.getAGenus();
            }
            else if (value.Equals("plant"))
            {
              lists = taxon.getPGenus();
            }

            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);
        }

        // GET: /AddReview/GetSpecies
        public ActionResult GetSpecies(bool ajax, string genusID, string kingdom)
        {
            IGenericRepository gen = new GenericRepository();
            ITaxonRepository taxon = new TaxonRepository();
            
            IList<AGeneralTaxon> lists = null;

            int _genusID = int.Parse(genusID);

            if (kingdom.Equals("animal"))
                lists = taxon.getASpeciesbyGenus(_genusID);
            else
            {
                lists = taxon.getPSpeciesbyGenus(_genusID);
            }


            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);
        }


        //
        // GET: /AddReview/AddReview
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult AddReview()
        {
            IGenericRepository gen = new GenericRepository();
            ITaxonRepository taxons = new TaxonRepository();

            IList<AGeneralTaxon> initList = new[] { new AGeneralTaxon { RecId = 1, TaxonName = "- Please Select -" } };

            ViewData["addphase"] = new SelectList(gen.getAllPhase(), "ID", "PhaseDesc");
            ViewData["committee"] = new SelectList(gen.getAllCommittees(),"ID","Description");
            //ViewData["genus"] = new SelectList(taxons.getAGenus(),"RecID","TaxonName");
            //ViewData["species"] = new SelectList(taxons.getASpecies(), "RecID", "TaxonName");

            ViewData["countries"] = ViewData["genus"] = ViewData["species"] = new SelectList(initList, "RecID", "TaxonName");
           // ViewData["countries"] = new SelectList(taxons.)
            
            return View();
        }

        //
        // GET: /AddReview/Create
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AddReview/Create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR + "," + UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ITaxonRepository taxon = new TaxonRepository();
                IGenericRepository generics = new GenericRepository();
                IReviewRepository reviews = new ReviewRepository();
                // TODO: Add insert logic here
                TblReview r = new TblReview();

                int kingdom = 0;
                int reviewtype = 0;
                kingdom = collection["addkingdom"].Equals("animal") ?
                    generics.getExternalRef(UpdateUtils.ANIMALS, UpdateUtils.TYPE_KINGDOM) :
                    generics.getExternalRef(UpdateUtils.PLANTS, UpdateUtils.TYPE_KINGDOM);

                //reviewtype = collection["reviewtype"].Equals("normal") ? 
                //    generics.getExternalRef(UpdateUtils.REVIEW_NORMAL, UpdateUtils.TYPE_REVIEW) :
                //    generics.getExternalRef(UpdateUtils.REVIEW_ADHOC, UpdateUtils.TYPE_REVIEW);

                r.CountryID = int.Parse(collection["countries"]);
                r.AddedBy = 2;
                r.AddedByName= Membership.GetUser().ToString();
                r.DateAdded = DateTime.Now;
                r.PhaseID = int.Parse(collection["addphase"]);
                int speciesId =  int.Parse(collection["species"]);
                r.TaxonID = speciesId; 
                r.TaxonLevel = generics.getExternalRef(UpdateUtils.SPECIES, UpdateUtils.TYPE_TAXONLEVEL);
                r.KingdomID = kingdom;
               // r.CommitteeID = int.Parse(collection["committee"]);
                r.CommitteeID = 1;
                r.ReviewDate = DateTime.Now;
                r.ReviewType = 1;

                int ID= taxon.SaveReview(r);

                ReviewStatus rs = new ReviewStatus();
                rs.Status = generics.getExternalRef(UpdateUtils.SELECTION, UpdateUtils.REVIEWSTATUS);
                rs.DateAdded = DateTime.Now;
                rs.ReviewID = ID;
                reviews.saveReviewStatus(rs);

              //  return RedirectToAction("List","AddReview");
                return RedirectToAction("Details", "ProcessReview", new {id = ID});
            }
            catch
            {
                //Do nothing - caught below
            }
            return RedirectToAction("AddReview", "AddReview");
        }


       
        //
        // GET: /AddReview/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult EditReview(int id)
        {
            IReviewRepository reviews = new ReviewRepository();
            IGenericRepository generics = new GenericRepository();
            ITaxonRepository taxons = new TaxonRepository();

            TblReview review = reviews.getSingleReviewEdit(id);
            ViewData["addphase"] = new SelectList(generics.getAllPhase(), "ID", "PhaseDesc",review.PhaseID);
            ViewData["committee"] = new SelectList(generics.getAllCommittees(), "ID", "Description", review.CommitteeID);

            int animal = generics.getExternalRef(UpdateUtils.ANIMALS, UpdateUtils.TYPE_KINGDOM);
            int kingdom = (int) review.KingdomID;
            IList<AGeneralTaxon> lists_countries, lists_genus, lists_species = null;
            int SpeciesID = review.TaxonID.GetValueOrDefault();
            Taxons genus = taxons.getTaxonbySpecies(SpeciesID, (int) review.KingdomID);

            if (review.KingdomID == animal)
            {
                lists_countries = taxons.getCountries(SpeciesID, UpdateUtils.SPECIES, UpdateUtils.ANIMALS);
                lists_genus = taxons.getAGenus();
                lists_species= taxons.getASpeciesbyGenus(genus.genrecid);
            }
            else
            {
                lists_countries = taxons.getCountries(SpeciesID, UpdateUtils.SPECIES, UpdateUtils.PLANTS);
                lists_genus = taxons.getPGenus();
                lists_species= taxons.getPSpeciesbyGenus(genus.genrecid);
            }

            ViewData["animal"] = animal;
            ViewData["kingdom"] = kingdom;
            ViewData["countries"] = new SelectList(lists_countries, "RecID", "TaxonName", review.CountryID);
            ViewData["genus"] = new SelectList(lists_genus, "RecID", "TaxonName", genus.genrecid);
            ViewData["species"] = new SelectList(lists_species, "RecID", "TaxonName", SpeciesID);

            return View();
        }

        //
        // POST: /AddReview/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditReview(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                IReviewRepository reviews = new ReviewRepository();
                ITaxonRepository taxons = new TaxonRepository();
                TblReview review = reviews.getSingleReviewEdit(id);
                IGenericRepository generics = new GenericRepository();

                int kingdom = 0;
                int reviewtype = 0;
                kingdom = collection["kingdom"].Equals("animal") ?
                    generics.getExternalRef(UpdateUtils.ANIMALS, UpdateUtils.TYPE_KINGDOM) :
                    generics.getExternalRef(UpdateUtils.PLANTS, UpdateUtils.TYPE_KINGDOM);

                //reviewtype = collection["reviewtype"].Equals("normal") ? 
                //    generics.getExternalRef(UpdateUtils.REVIEW_NORMAL, UpdateUtils.TYPE_REVIEW) :
                //    generics.getExternalRef(UpdateUtils.REVIEW_ADHOC, UpdateUtils.TYPE_REVIEW);

                review.CountryID = int.Parse(collection["countries"]);
                review.AddedBy = 2;
                review.DateAdded = DateTime.Now;
                review.PhaseID = int.Parse(collection["addphase"]);
                review.TaxonID = int.Parse(collection["species"]); ;
                review.TaxonLevel = generics.getExternalRef(UpdateUtils.SPECIES, UpdateUtils.TYPE_TAXONLEVEL);
                review.KingdomID = kingdom;
                //review.CommitteeID = int.Parse(collection["committee"]);
                review.CommitteeID = 1;
                //r.ReviewDate = DateTime.Now;
                //r.ReviewType = reviewtype;

                int ID = taxons.SaveReview(review);

                //ReviewStatus rs = new ReviewStatus();
                //rs.Status = generics.getExternalRef(UpdateUtils.SELECTION, UpdateUtils.REVIEWSTATUS);
                //rs.DateAdded = DateTime.Now;
                //rs.ReviewID = ID;
                //reviews.saveReviewStatus(rs);

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}