using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Security;
using System.Windows.Forms.VisualStyles;
using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;

namespace SigTrade.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()

        {
            ITaxonRepository taxons = new TaxonRepository();
            IGenericRepository generics = new GenericRepository();
            ViewData["countries"] = new SelectList(taxons.getReportCountries(), "ID", "Description");
            ViewData["paragraphs"] = new SelectList(taxons.getReportParagraphActions(), "ID", "Description");
            ViewData["phases"] = new SelectList(generics.getAllPhase(), "ID", "PhaseDesc");
            ViewData["concerns"] = new SelectList(generics.getAllLevelofConcerns(), "ID", "Description");
            ViewData["species"] = new SelectList(taxons.getASpeciesSearch(), "RecID", "TaxonName");

            IList<UsersParagraphLink> users = generics.getAllUsersBySource();
            int usercount = users.Count;
            for (int j = 0; j < usercount; j++) {
                users[j].UserID = Membership.GetUser(new Guid(users[j].UserID)).UserName;
                
            }

            ViewData["actors"] =
                new SelectList(users, "UserID", "UserID");


            return View();
        }

        //
        // GET: /Report/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Report/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Report/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Report/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

       
        //
        // POST: /Report/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: /Report/GenericReport/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GenericReport(FormCollection collection) {
            int i = 10;

            IGenericRepository generics = new GenericRepository();

            int country = int.Parse(collection["countries"].ToString());
            int paLibId = int.Parse(collection["paragraphs"].ToString());
            int concern = int.Parse(collection["concerns"].ToString());
            int phase = int.Parse(collection["phases"].ToString());
            string actors = collection["actors"].ToString();

            int taxonid = 0;
            string reportkingdom = collection["reportkingdom"];
            if (collection["species"] == null)
                taxonid = -1;
            else
                taxonid = int.Parse(collection["species"].ToString());
            int kingdom = 0;

            switch(reportkingdom)
            {
                case UpdateUtils.ALL_KINGDOM:
                    kingdom = 0;
                    break;
                case UpdateUtils.ANIMALS:
                    kingdom = 1;
                    break;
                case UpdateUtils.PLANTS:
                    kingdom = 2;
                    break;
            }

            //DataSet dataTest = SPs.SpGetReportByCountries(country).GetDataSet();
            actors = actors.Equals("-1") ? actors : Membership.GetUser(actors).ProviderUserKey.ToString();

            DataSet dataTest = generics.getReportData(country, phase,paLibId, concern,actors, kingdom, taxonid);
     
            DataRowCollection colResults = dataTest.Tables[0].Rows;
            int count = colResults.Count;

            TempData["reportData"] = dataTest;
            return RedirectToAction("CountryView");

            return View();
        }



        // GET: /Report/GenericReport/
        public ActionResult GenericReport() {
            int i = 10;

            DataSet dataTest = SPs.SpReportGetCountries().GetDataSet();

            i = dataTest.Tables[0].Rows.Count;

            ViewData["reportData"] = dataTest;

            return View();
        }

        // GET: /Report/GenericReport/
        public ActionResult CountryView() {
            int i = 10;

            ViewData["reportData"] = TempData["reportData"];

            return View();
        }


        // GET: /Report/GetSpeciesList
        public ActionResult GetSpeciesList(bool ajax, string kingdom) {
            IGenericRepository gen = new GenericRepository();
            ITaxonRepository taxon = new TaxonRepository();

            IList<AGeneralTaxon> lists = null;

            if (kingdom.Equals("animals"))
                lists = taxon.getASpeciesSearch();
            else {
                lists = taxon.getPSpeciesSearch();
            }
            
            // return Json(taxons.getCountries(3, UpdateUtils.PHYLUM, UpdateUtils.ANIMALS).ToList());
            return Json(lists);
        }





    }
}
