using Microsoft.AspNet.Identity;
using SnowTails.Models.Location;
using SnowTails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnowTails.WebMVC.Controllers
{
    public class LocationController : ApplicationBaseController
    {
        // GET: Location
        public ActionResult Index()
        {
            LocationService service = CreateLocationService();
            var model = service.GetLocations();
            return View(model);
        }

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLocationService();
            if (service.CreateLocation(model))
            {
                TempData["SaveResult"] = "Location successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Location could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateLocationService();
            var detail = service.GetLocationById(id);
            var model =
                new LocationEdit
                {
                    LocationId = detail.LocationId,
                    LocationName = detail.LocationName,
                    LocationCity = detail.LocationCity,
                    LocationAddress = detail.LocationAddress,
                    LocationPhone = detail.LocationPhone,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.LocationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateLocationService();

            if (service.UpdateLocation(model))
            {
                TempData["SaveResult"] = "The Location was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Location could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationService();
            var model = svc.GetLocationById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLocationService();
            service.DeleteLocation(id);
            TempData["SaveResult"] = "Location successfully deleted";
            return RedirectToAction("Index");
        }
    }
}