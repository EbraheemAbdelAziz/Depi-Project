using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class LocationController : Controller
    {
        private readonly IBaseRepository<Location> _location;

        public LocationController(IBaseRepository<Location> location)
        {
            _location = location;
        }
        // GET: LocationController
        public async Task<ActionResult> Index()
        {
            var locations = await _location.GetAll();
            return View("LocationList",locations);
        }

        // GET: LocationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var location = await _location.GetById(id);
            return View("LocationDetails",location);
        }

        // GET: LocationController/Create
        public async Task<ActionResult> Create()
        {
            return View("NewLocation");
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Location location)
        {
            try
            {
                await _location.AddItem(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ExistsError = "Something went wrong!";
                return View("NewLocation");
            }
        }

        // GET: LocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var location = await _location.GetById(id);
            if (location == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("EditLocation",location);
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Location location)
        {
            try
            {
                await _location.UpdateItem(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditLocation");
            }
        }

        // GET: LocationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var location = await _location.GetById(id);
            if (location == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("DeleteLocation",location);
        }

        // POST: LocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Location location)
        {
            try
            {
                await _location.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteLocation");
            }
        }
    }
}
