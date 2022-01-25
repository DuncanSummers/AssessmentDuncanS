using AssessmentDuncanS.Models;
using AssessmentDuncanS.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssessmentDuncanS.WebAPI.Controllers
{
    // after i made the message class in data layer, I added a controller, gonna make view later
    // after added messagelistitem model, was able to scaffold a view for the index
    [Authorize] //made it so views are only accessible to logged in users
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            // display all messages for current user, calling upon methods in the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            var model = service.GetMessages();

            return View(model);
        }

        //
        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //extract method
            var service = CreateMessageService();

            if (service.CreateMessage(model))
            {
                TempData["SaveResult"] = "Your message was sent.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Message could not be sent.");

            return View(model);
        }

        // Add Details to controller, create view
        public ActionResult Details(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        // Add Delete to controller, create default view
        public ActionResult Delete(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);

            return View(model);
        }

        // Add Delete Post method to remove from database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMessageService();

            service.DeleteMessage(id);

            TempData["SaveResult"] = "Message Deleted";
            return RedirectToAction("Index");
        }

        //extracted method
        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            return service;
        }
    }
}