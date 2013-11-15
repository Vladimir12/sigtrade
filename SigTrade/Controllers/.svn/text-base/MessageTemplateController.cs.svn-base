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
    public class MessageTemplateController : Controller
    {
        //
        // GET: /MessageTemplate/

        public ActionResult Index()
        {
            IMessageTemplateRepository model = new MessageTemplateRepository();
            ViewData["all_messages"] = model.getAll();
            return View();
        }



        //
        // GET: /message/show/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult Detail(int id)
        {
            IMessageTemplateRepository model = new MessageTemplateRepository();
            ViewData.Model = model.getById(id);
            return View();
        }

        //
        // GET: /message/create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult create()
        {
            //Generate new message object
            MessageTemplate message = new MessageTemplate();
            ViewData["edit"] = false;
            ViewData["message"] = message;
            return View();
        }

        //
        // POST: /Committees/create
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult create(FormCollection collection)
        {
            //Generate new Committee object
            MessageTemplateRepository message_template_rep = new MessageTemplateRepository();
            MessageTemplate message = new MessageTemplate();
            ViewData["edit"] = false;
            ViewData["message"] = message;

            try
            {
                return messageTemplateFormProcess(message, message_template_rep, collection);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to create message template: " + exception.Message;
                return RedirectToAction("create");
            }
        }

        //
        // GET: /Committees/edit/5
        [Authorize(Roles = UpdateUtils.ROLE_ADMINISTRATOR)]
        public ActionResult edit(int id)
        {
            MessageTemplateRepository message_rep = new MessageTemplateRepository();
            ViewData["message_id"] = id.ToString();
            ViewData.Model = message_rep.getById(id);
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
            MessageTemplateRepository message_rep = new MessageTemplateRepository();
            MessageTemplate message = new MessageTemplate();

            //GET Committee
            try
            {
                message = message_rep.getById(Int32.Parse(collection["message_id"]));
                TempData["message"] = message;
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve message: " + exception.Message;
                return RedirectToAction("edit", new { controller = "MessageTemplate", id = collection["message_id"] });
            }


            //UPDATE Committee
            try
            {
                return messageTemplateFormProcess(message, message_rep, collection);
            }
            catch (Exception exception)
            {

                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to update message: " + exception.Message;
                return RedirectToAction("edit", new { controller = "MessageTemplate", id = collection["message_id"] });
            }
        }


        //PROCESS EDIT AND CREATE FORMS
        private ActionResult messageTemplateFormProcess(MessageTemplate message, MessageTemplateRepository message_rep, FormCollection collection)
        {
            try
            {

                message.Title = collection["title"];
                message.Body = collection["body"];
                message.DaysDelta = Convert.ToInt32(collection["days_delta"]);
                if (collection["disable"] != null) //Only appears on the edit form
                    message.Disabled = collection["disable"].ToString().Contains("true"); //Check box returns 2 values, one of which is whether it's ticked and the other is "Remember me"
                message_rep.save(message);

                TempData["flash"] = "Message Template saved: " + message.Title;

                return RedirectToAction("Detail", new { ID = message.Id });
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
            MessageTemplateRepository m_rep = new MessageTemplateRepository();
            MessageTemplate m = new MessageTemplate();

            //GET Committee
            try
            {
                m = m_rep.getById(id);
            }
            catch (Exception exception)
            {
                //IF THERE IS A MESS UP, RETURN ERROR TO FRONT
                TempData["flash"] = "Unable to retrieve message: " + exception.Message;
                return RedirectToAction("Index");
            }


            //DELETE Committee
            try
            {
                m_rep.delete(m);
                TempData["flash"] = "Deleted message.";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["flash"] = "Unable to delete message: " + exception.Message;
                return RedirectToAction("Index");
            }
        }



    }
}
