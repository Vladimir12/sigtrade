using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Controllers
{
    public class CommitteesController : Controller
    {
        //
        // GET: /Committees
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult index()
        {
            CommitteeLibRepository committee_rep = new CommitteeLibRepository();

            ViewData["all_committees"] = committee_rep.getAll();
            return View();
        }

        //
        // GET: /Committees/show/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult show(int id)
        {
            return View();
        }

        //
        // GET: /Committees/create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult create()
        {
            //Generate new Committee object
            CommitteeLibRepository committee_rep = new CommitteeLibRepository();
            CommitteeLib committee = new CommitteeLib();
            ViewData["edit"] = false;
            ViewData["committee"] = committee;
            return View();
        }

        //
        // POST: /Committees/create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult create(FormCollection collection)
        {
            //Generate new Committee object
            CommitteeLibRepository committee_rep = new CommitteeLibRepository();
            CommitteeLib committee = new CommitteeLib();
            ViewData["edit"] = false;
            ViewData["committee"] = committee;

            try
            {
                return committeeFormProcess(committee, committee_rep, collection);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to create committee: " + exception.Message;
                return RedirectToAction("create");
            }
        }

        //
        // GET: /Committees/edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult edit(int id)
        {
            CommitteeLibRepository committee_rep = new CommitteeLibRepository();
            ViewData["committee_id"] = id.ToString();
            ViewData["committee"] = committee_rep.getCommittee(id);
            ViewData["edit"] = true;

            return View();
        }

        //
        // POST: /Committees/update/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult edit(FormCollection collection)
        {
            //Generate new Committee object for form if error        
            CommitteeLibRepository committee_rep = new CommitteeLibRepository();
            CommitteeLib committee = new CommitteeLib();

            //GET Committee
            try
            {
                committee = committee_rep.getCommittee(Int32.Parse(collection["committee_id"]));
                TempData["committee"] = committee;
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve committee: " + exception.Message;
                return RedirectToAction("edit", new { controller = "Committees", id = collection["committee_id"] });
            }


            //UPDATE Committee
            try
            {
                return committeeFormProcess(committee, committee_rep, collection);
            }
            catch (Exception exception)
            {

                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to update committee: " + exception.Message;
                return RedirectToAction("edit", new { controller = "Committees", id = collection["committee_id"] });
            }


        }


        //PROCESS EDIT AND CREATE FORMS
        private ActionResult committeeFormProcess(CommitteeLib committee, CommitteeLibRepository committee_rep, FormCollection collection)
        {
            try
            {

                committee.Description = collection["committee_description"];
                committee_rep.save(committee);

                TempData["flash"] = "Committee: " + committee.Description;
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                throw new Exception("A data entry problem has occurred.");
            }
        }

        //
        // POST: /Committees/delete/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult delete(int id)
        {
            CommitteeLibRepository committee_rep = new CommitteeLibRepository();
            CommitteeLib committee = new CommitteeLib();

            //GET Committee
            try
            {
                committee = committee_rep.getCommittee(id);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve committee: " + exception.Message;
                return RedirectToAction("Index");
            }


            //DELETE Committee
            try
            {
                committee_rep.delete(committee);
                TempData["flash"] = "Deleted committee.";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["flash"] = "Unable to delete committee: " + exception.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
