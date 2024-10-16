using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class LocationController : Controller
    {
        private readonly IBaseRepository<Location> _location;
        private IUploadFile _uploadFile;
        public LocationController(IBaseRepository<Location> location, IUploadFile uploadFile)
        {
            _location = location;
            _uploadFile = uploadFile;
        }
        // GET: LocationController
        public async Task<ActionResult> Index()
        {
            var locations = await _location.GetAll();
            return View("LocationList",locations);
        }

        // GET: LocationController/Create
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            return View("NewLocation");
        }

        // POST: LocationController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Location location)
        {
            try
            {
                if (location.ImageFile != null)
                {
                    //~/template/img/
                    string FileName = await _uploadFile.UploadFileAsync("\\template\\img\\", location.ImageFile);
                    location.ImageUrl = FileName;
                }
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,Location location)
        {
            try
            {
                var existingFlight = await _location.GetById(id);
                if (location.ImageFile != null)
                {
                    string fileName = await _uploadFile.UploadFileAsync("\\template\\img\\", location.ImageFile);
                    location.ImageUrl = fileName;
                }
                else
                {
                    location.ImageUrl = existingFlight.ImageUrl;
                }
                await _location.UpdateItem(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditLocation");
            }
        }

        // GET: LocationController/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
