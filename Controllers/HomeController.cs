using BPP_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPP_Final.Controllers
{
    public class HomeController : Controller
    {
        BPPDBEntities entities = new BPPDBEntities();

        public ActionResult Index() //This is where the data analysis in done
        {
            return View();
        }

        [Authorize]
        public ActionResult EditUserSettings()
        {

            var allAnalyzedElements = entities.AnalyzedElements.ToList();
            return View(allAnalyzedElements);
        }

        [Authorize]
        public ActionResult EditParameter(int param)
        {
            var user = entities.Users.FirstOrDefault(f => f.EmailAddress == User.Identity.Name);
            if (user == null)
                return HttpNotFound();
            User u = user;

            var paramToEdit = entities.UsersAnalyzedElements
                .FirstOrDefault(f => f.UserId == u.Id && f.AnalyzedElementId == param);

            UsersAnalyzedElement p = paramToEdit;
            return View(p);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditParameter(UsersAnalyzedElement p)
        {
            if (!this.ModelState.IsValid)
            {
                return View(p);
            }

            //var user = entities.Users.FirstOrDefault(f => f.EmailAddress == User.Identity.Name);
            //if (user == null)
            //    return HttpNotFound();
            //User u = user;

            //UsersAnalyzedElement paramToModify = getUsersAnalyzedElementsFromDB(u, p);

            //paramToModify.ChosenValue = p.ChosenValue;
            //paramToModify.Importance = p.Importance;

            entities.Entry(p).State = EntityState.Modified;
            entities.SaveChanges();

            return RedirectToAction("EditUserSettings");
        }

        [Authorize]
        public ActionResult TopLocations() //This is where the data analysis in done
        {
            var email = User.Identity.Name;
            User usr = entities.Users.FirstOrDefault(u => u.EmailAddress == email);
            List<UsersAnalyzedElement> toAnalyse = entities.UsersAnalyzedElements.Where(uae => uae.UserId == usr.Id).ToList();

            return View(toAnalyse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}