using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using SignificantTrade.Models;
using SignificantTradeSSRepository;
using SignificantTradeSS;
using SigTrade.Interfaces;
using SigTrade.Models;

namespace SignificantTrade.Controllers
{
    public class MeetingsController : Controller
    {
        //
        // GET: /Home/
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Index()
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();
            ViewData.Model = MeetingLibRep.getAllMeetingLibs();
            return View();
        }

        //
        // GET: /Home/Details/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Create()
        {
            
            return View();
        }

        //
        // POST: /Home/Create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
               UpdateUtils.InsertMeetingLib(collection);
                return RedirectToAction("Index");
            }  
            catch (Exception e)
            {
            
                Console.WriteLine("{0} Exception caught.", e);
                return View();
            }
        }

        //
        // GET: /Home/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Edit(int id)
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();

            MeetingLib m = MeetingLibRep.getMeetingLibByID(id);
            ViewData.Model = m;
            return View();
        }

        //
        // POST: /Home/Edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();
                MeetingLib m = MeetingLibRep.getMeetingLibByID(id);

                m.MeetingLibDesc = collection["meeting_description"];
                m.MeetingLibNumber = collection["meeting_number"];
                m.MeetingLibDate = DateTime.Parse(collection["meeting_date"]);
                m.DateModified = DateTime.Now;

                MeetingLibRep.Save(m);

                return RedirectToAction("Index");
            }
            catch (SubSonic.SqlQueryException e)
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
                IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();
                MeetingLib m = MeetingLibRep.getMeetingLibByID(id);
                ViewData.Model = m;
                return View();
            }
        }

        //
        // POST: /Meetings/delete/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult delete(int id)
        {
            IMeetingLibRepository MeetingLibRep = new MeetingLibRepository();
            MeetingLib ml = new MeetingLib();

            //GET MEETING
            try
            {
                ml = MeetingLibRep.getMeetingLibByID(id);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve meeting: " + exception.Message;
                return RedirectToAction("Index");
            }


            //DELETE MEETING
            try
            {
                MeetingLibRep.Delete(ml);
                TempData["flash"] = "Deleted meeting.";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["flash"] = "Unable to delete meeting: " + exception.Message;
                return RedirectToAction("Index");
            }
        }

    }
}