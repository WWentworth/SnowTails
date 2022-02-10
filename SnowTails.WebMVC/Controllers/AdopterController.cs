using Microsoft.AspNet.Identity;
using SnowTails.Models.Adopter;
using SnowTails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnowTails.WebMVC.Controllers
{
    [Authorize]
    public class AdopterController : Controller
    {
        // GET: Adopter
        public ActionResult Index()
        {
            AdopterService service = CreateAdopterService();
            var model = service.GetAdopters();
            return View(model);
        }

        private AdopterService CreateAdopterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AdopterService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdopterCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAdopterService();
            if (service.CreateAdopter(model))
            {
                TempData["SaveResult"] = "Adopter successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Adopter could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateAdopterService();
            var model = svc.GetAdopterById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAdopterService();
            var detail = service.GetAdopterById(id);
            var model =
                new AdopterEdit
                {
                    AdopterId = detail.AdopterId,
                    AdopterName = detail.AdopterName,
                    AdopterAddress = detail.AdopterAddress,
                    AdopterPhone = detail.AdopterPhone,
                    OtherPets = detail.OtherPets,
                    FencedYard = detail.FencedYard
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdopterEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.AdopterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAdopterService();

            if (service.UpdateAdopter(model))
            {
                TempData["SaveResult"] = "The Adopter was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Adopter could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAdopterService();
            var model = svc.GetAdopterById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAdopterService();
            service.DeleteAdopter(id);
            TempData["SaveResult"] = "Adopter successfully deleted";
            return RedirectToAction("Index");
        }
    }
}