using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SignificantTradeSSRepository;
using SigTrade.Interfaces;
using SigTrade.Models;

namespace SigTrade.Controllers
{
    public class RecommendationController : Controller
    {
        //
        // GET: /Recommendation/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Recommendation/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Recommendation/Create
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult CreateRecommendation()
        {
            return View();
        } 

        //
        // POST: /Recommendation/Create
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateRecommendation(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here


                string recommendation = collection["recommendation"].ToString();
                int committee_id = int.Parse(collection["Committees"].ToString());
                DateTime recdeadlinedate = DateTime.Parse(collection["recdeadlinedate"].ToString());
                DateTime recdate = DateTime.Parse(collection["recdate"].ToString());

                int PActionID = int.Parse(collection["SourceID"].ToString());

                IRecommendationsRepository recs = new RecommendationsRepository();
                IGenericRepository generic = new GenericRepository();
                Recommendation r = new Recommendation();

                r.AddedDate = DateTime.Now;
                r.CommitteeID = committee_id;
                r.DeadlineDate = recdeadlinedate;
                r.RecDate = recdate;
                r.RecommendationX = recommendation;
                r.ParagraphActionID = PActionID;

                int i= recs.SaveRec(r);

                ViewData["Committees"] = new SelectList(generic.getAllCommitteesSelect(), "ID", "Description");
                ViewData["recommendations"] = recs.getAllRecommendationsByParagraph(PActionID);
                ViewData["PActionID"] = PActionID;
                return PartialView("Recommendations");

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Recommendation/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Recommendation/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_DATA_MANAGER)]
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
    }
}
