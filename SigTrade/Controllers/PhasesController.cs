using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SignificantTradeSSRepository;
using SigTrade.Models;

namespace SigTrade.Controllers
{
    public class PhasesController : Controller
    {
        //
        // GET: /Phases/
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult index()
        {
            PhaseRepository phase_rep = new PhaseRepository();

            ViewData["all_phases"] = phase_rep.getAll();
            return View();
        }

        //
        // GET: /Phases/show/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult show(int id)
        {
            return View();
        }

        //
        // GET: /Phases/create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult create()
        {
            //Generate new phase object
            PhaseRepository phase_rep = new PhaseRepository();
            Phase phase = new Phase();
            ViewData["edit"] = false;
            ViewData["phase"] = phase;
            return View();
        } 

        //
        // POST: /Phases/create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult create(FormCollection collection)
        {
            //Generate new phase object
            PhaseRepository phase_rep = new PhaseRepository();
            Phase phase = new Phase();
            ViewData["edit"] = false;
            ViewData["phase"] = phase;

            try
            {
                return phaseFormProcess(phase, phase_rep, collection);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to create phase: " + exception.Message;
                return RedirectToAction("create");
            } 
        }

        //
        // GET: /Phases/edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult edit(int id)
        {
            PhaseRepository phase_rep = new PhaseRepository();
            ViewData["phase_id"] = id.ToString();
            ViewData["phase"] = phase_rep.getPhase(id);
            ViewData["edit"] = true;

            return View();
        }

        //
        // POST: /Phases/update/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult edit(FormCollection collection)
        {
            //Generate new phase object for form if error        
            PhaseRepository phase_rep = new PhaseRepository();
            Phase phase = new Phase();
    
            //GET PHASE
            try
            {
                phase = phase_rep.getPhase(Int32.Parse(collection["phase_id"]));
                TempData["phase"] = phase;
            } 
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve phase: " + exception.Message;
                return RedirectToAction("edit", new {controller = "Phases", id = collection["phase_id"]});
            }


            //UPDATE PHASE
            try
            {
                return phaseFormProcess(phase, phase_rep, collection);
            } 
            catch (Exception exception)
            {
          
              //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
              TempData["flash"] = "Unable to update phase: " + exception.Message;
              return RedirectToAction("edit", new { controller = "Phases", id = collection["phase_id"] });
            } 

                  
        }


        //PROCESS EDIT AND CREATE FORMS
        private ActionResult phaseFormProcess(Phase phase, PhaseRepository phase_rep, FormCollection collection)
        {
            try
            {

                phase.PhaseDesc = collection["phase_description"];
                phase.PhaseStartDate = DateTime.Parse(collection["start_date"]);
                phase.Deleted = false;
                phase_rep.save(phase);

                TempData["flash"] = "Phase: " + phase.PhaseDesc;
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                throw new Exception("A data entry problem has occurred.");
            }  
        }

        //
        // POST: /Phases/delete/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult delete(int id)
        {
            PhaseRepository phase_rep = new PhaseRepository();
            Phase phase = new Phase();

            //GET PHASE
            try
            {
                phase = phase_rep.getPhase(id);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve phase: " + exception.Message;
                return RedirectToAction("Index");
            }


            //DELETE PHASE
            try
            {
               phase_rep.delete(phase);
               TempData["flash"] = "Deleted phase.";
               return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["flash"] = "Unable to delete phase: " + exception.Message;
                return RedirectToAction("Index");
            }
        }




    }
}
