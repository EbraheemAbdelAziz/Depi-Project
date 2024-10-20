using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class TravelPackagesController : Controller
    {
        // GET: TravelPackagesController
        private IBaseRepository<TravelPackage> _TravelPackages;
        private IUploadFile _uploadFile;
        private readonly IBaseRepository<Location> _location;
        public TravelPackagesController(IBaseRepository<TravelPackage> travelPackages, IUploadFile uploadFile, IBaseRepository<Location> location)
        {
            _TravelPackages = travelPackages;
            _uploadFile = uploadFile;
            _location = location;
        }

        public async Task <ActionResult> Index(string search)
        {
            IEnumerable<TravelPackage> travelPackages;
            if (search != null)
            {
                travelPackages = await _TravelPackages.GetAll(tb => tb.Destination.LocationName.ToLower().Contains(search.ToLower()) || tb.Destination.Country.ToLower().Contains(search.ToLower()) || tb.PackageName.ToLower().Contains(search.ToLower()), new[] { "Destination" });
            }
            else
            {
                travelPackages = await _TravelPackages.GetAll(null, new[] { "Destination" });
            }
            return View("TravelPackageList",travelPackages);
        }
        public async Task <ActionResult> Search(string search)
        {
            IEnumerable<TravelPackage> travelPackages;
            if (search != null)
            {
                travelPackages = await _TravelPackages.GetAll(tb => tb.Destination.LocationName.ToLower().Contains(search.ToLower()) || tb.Destination.Country.ToLower().Contains(search.ToLower()) || tb.PackageName.ToLower().Contains(search.ToLower()), new[] { "Destination" });
            }
            else
            {
                travelPackages = await _TravelPackages.GetAll(null, new[] { "Destination" });
            }
            return PartialView("_TravelPackageCards", travelPackages);
        }

        // GET: TravelPackagesController/Details/5
        public async Task <ActionResult> Details(int id)
        {
            var travelPackage = await _TravelPackages.GetById(id);
            travelPackage.Destination = await _location.GetById(travelPackage.DestinationId);
            return View("TravelPackageDetails", travelPackage);
        }

        // GET: TravelPackagesController/Create
        [Authorize(Roles = "Admin")]
        public async Task <ActionResult> Create()
        {
            var locations = await _location.GetAll();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName", "ImageUrl");
            return View("NewTravelPackage");
        }

        // POST: TravelPackagesController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(TravelPackage travelPackage)
        {
            try
            {

                if (travelPackage.ImageFile != null)
                {
                    string FileName = await _uploadFile.UploadFileAsync("\\Images\\TravelImage\\", travelPackage.ImageFile);
                    travelPackage.PackageImage = FileName;
                }
                travelPackage.Duration = travelPackage.EndDate.Day - travelPackage.StartDate.Day;
                await _TravelPackages.AddItem(travelPackage);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;   
                return View("NewTravelPackage");
            }
        }

        // GET: TravelPackagesController/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task <ActionResult> Edit(int id)
        {
            var travelPackage = await _TravelPackages.GetById(id);
            if (travelPackage == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var locations = await _location.GetAll(l=>l.LocationId != travelPackage.DestinationId);
            travelPackage.Destination = await _location.GetById(travelPackage.DestinationId);
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName", "ImageUrl");
            return View("EditTravelPackage",travelPackage);
        }

        // POST: TravelPackagesController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, TravelPackage travelPackage)
        {
            try
            {
                if (travelPackage.ImageFile != null)
                {
                    string FileName = await _uploadFile.UploadFileAsync("\\Images\\TravelImage\\", travelPackage.ImageFile);
                    travelPackage.PackageImage = FileName;
                }
                else
                {
                    travelPackage.PackageImage = _TravelPackages.GetById(travelPackage.PackageId).Result.PackageImage;
                }
                travelPackage.Duration = travelPackage.EndDate.Day - travelPackage.StartDate.Day;
                
                await _TravelPackages.UpdateItem(travelPackage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditTravelPackage");
            }
        }

        // GET: TravelPackagesController/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task <ActionResult> Delete(int id)
        {
            var travelpackage = await _TravelPackages.GetById(id);
            return View("DeleteTravelPackage",travelpackage);
        }

        // POST: TravelPackagesController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _TravelPackages.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteTravelPackage");
            }
        }
    }
}
