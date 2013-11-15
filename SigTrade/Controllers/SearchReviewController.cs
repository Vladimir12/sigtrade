using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;

namespace SigTrade.Controllers
{
    public class SearchReviewController : Controller
    {
        //
        // GET: /SearchReview/

        public ActionResult Search(bool? NoSearchResults)
        {
            IGenericRepository generics = new GenericRepository();
            ITaxonRepository taxon = new TaxonRepository();


            if ((NoSearchResults != null) && (bool)NoSearchResults)
            {
                //ViewData["nosearchresults"] = true;
                TempData["flash"] = "No Search Results found. Please try Again!";
            }

            IList<AGeneralTaxon> initList = new[] { new AGeneralTaxon { RecId = 1, TaxonName = "Select" } };
            //ViewData["searchcountry"] = new SelectList(generics.getAllCountries(), "CtyRecId", "CtyShort");

            IList<AGeneralTaxon> countriesList = taxon.getCountriesSearch(0, UpdateUtils.SPECIES,
                                                                          UpdateUtils.ALL_KINGDOM);

            int count = countriesList.Count;

            ViewData["searchcountry"] = new SelectList(taxon.getCountriesSearch(0, UpdateUtils.SPECIES, UpdateUtils.ALL_KINGDOM), "RecID", "TaxonName");

            ViewData["phase"] = new SelectList(generics.getAllPhase(),"ID","PhaseDesc");
            ViewData["acountries"] = new SelectList(initList, "RecID", "TaxonName");

            ViewData["agenus"] = new SelectList(taxon.getAGenusSearch(), "RecID", "TaxonName");
            ViewData["aspecies"] = new SelectList(taxon.getASpeciesSearch(), "RecID", "TaxonName");

            return View();
        }

      
        //GET: /SearchReview/SetLocale
        public ActionResult SetLocale(int? ID)    
        {

            int locale;
            locale = ID ?? 0;
            string localeType= "";
            
            switch (locale)
            {
                case 0:
                    localeType = UpdateUtils.ENGLISH_EN;
                    break;
                case 1:
                    localeType = UpdateUtils.FRENCH_FR;
                    break;
                case 2:
                    localeType = UpdateUtils.SPANISH_ES;
                    break;
                default:
                    localeType = UpdateUtils.ENGLISH_EN;
                    break;

            }
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(localeType);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture
                  (localeType);
                Session["locale"] = localeType;

            string return_url = null;
            if (Request.UrlReferrer.AbsolutePath != null)
                return_url = Request.UrlReferrer.AbsolutePath;

            return new RedirectResult(return_url);
           // return RedirectToAction("Search");

        }

        //
        // GET: /SearchReview/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SearchReview/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SearchReview/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SearchReview/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SearchReview/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }
        }

        // GET: /SearchReview/GetCountries

        public ActionResult GetCountriesSearch(bool ajax, string speciesID, string kingdom)
        {
            IGenericRepository gen = new GenericRepository();

            ITaxonRepository taxon = new TaxonRepository();

            IList<AGeneralTaxon> lists = null;
            int _speciesID = int.Parse((speciesID));

            if (kingdom.Equals("animals") || kingdom.Equals("animal"))
            {
                lists = taxon.getCountriesSearch(_speciesID, UpdateUtils.SPECIES, UpdateUtils.ANIMALS);
            }
            else if (kingdom.Equals("plants") || kingdom.Equals("plant"))
            {
                lists = taxon.getCountriesSearch(_speciesID, UpdateUtils.SPECIES, UpdateUtils.PLANTS);
            }
            else if (kingdom.Equals("all"))
            {
                lists = taxon.getCountriesSearch(_speciesID, UpdateUtils.SPECIES, UpdateUtils.ALL_KINGDOM);
            }

            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);

        }

        // GET: /SearchReview/GetGenus
        public ActionResult GetGenusSearch(bool ajax, string value)
        {
            IGenericRepository gen = new GenericRepository();
            ITaxonRepository taxon = new TaxonRepository();

            IList<AGeneralTaxon> lists = null;

            if (value.Equals("animals") || value.Equals("animal"))
            {
                lists = taxon.getAGenusSearch();
            }
            else if (value.Equals("plants") || value.Equals("plant"))
            {
                lists = taxon.getPGenusSearch();
            }

            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);
        }

        // GET: /SearchReview/GetGenus
        public ActionResult GetSpeciesSearch(bool ajax, string genusID, string kingdom)
        {
            IGenericRepository gen = new GenericRepository();
            ITaxonRepository taxon = new TaxonRepository();

            IList<AGeneralTaxon> lists = null;

            int _genusID = int.Parse(genusID);

            if (kingdom.Equals("animal"))
                lists = taxon.getASpeciesbyGenusSearch(_genusID);
            else
            {
                lists = taxon.getPSpeciesbyGenusSearch(_genusID);
            }


            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);
        }


        //GET: :/SearchReview/GetParagraph
        public ActionResult GetParagraph(string ID)
        {
            IGenericRepository generics = new GenericRepository();

            ParagraphActionLib palib = null;
            if (ID != null && (ID.Length >0))
            {
                int i = int.Parse(ID.ToString());
                palib = generics.getPActionLib(i);
            }
            return Json(palib);
        }


        //Autocomplete in search
        public ActionResult Lookup(string q, int limit) {
            var repo = new SPRepository();
            var list = repo.searchByTaxon(q);
            if (list != null)
            {
                var data = from s in list select new {s.TaxonName};
                return Json(data);
            }
            return null;
        }



    }
}
