using Microsoft.AspNet.Identity;
using SnowTails.Models.Dog;
using SnowTails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnowTails.WebMVC.Controllers
{
    [Authorize]
    public class DogController : ApplicationBaseController
    {
        // GET: Dog
        public ActionResult Index()
        {
            DogService service = CreateDogService();
            var model = service.GetDogs();
            return View(model);
        }

        private DogService CreateDogService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DogService(userId);
            return service;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDogService();
            if (service.CreateDog(model))
            {
                TempData["SaveResult"] = "Dog successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Dog could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateDogService();
            var detail = service.GetDogById(id);
            var model =
                new DogEdit
                {
                    DogId = detail.DogId,
                    DogName = detail.DogName,
                    Sex = detail.Sex,
                    Age = detail.Age,
                    Fixed = detail.Fixed,
                    Information = detail.Information,
                    LocationName = detail.LocationName
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.DogId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateDogService();

            if (service.UpdateDog(model))
            {
                TempData["SaveResult"] = "The Dog was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The Dog could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDogService();
            var model = svc.GetDogById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDogService();
            service.DeleteDog(id);
            TempData["SaveResult"] = "Dog successfully deleted";
            return RedirectToAction("Index");
        }
        public ActionResult AdoptionEdit(int id)
        {
            AdoptionUpdate(id);
            return RedirectToAction("Details", new { id = id });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("api/Dog/AdoptDog")]
        public void AdoptionUpdate(int id)
        {
            //var id = RouteData.Values["id"] + Request.Url.Query;
            //var dogId = Convert.ToInt32(id);
            var service = CreateDogService();

            if (service.AdoptDog(id))
            {
                TempData["SaveResult"] = "You are the pending adopter!";

            }
            ModelState.AddModelError("", "The Adopter could not be updated.");
            //return RedirectToAction("Details", id);
        }

    }
}