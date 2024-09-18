using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class TravelPackagesController : Controller
    {
        // GET: TravelPackagesController
        private IBaseRepository<TravelPackage> _TravelPackages;

        public TravelPackagesController(IBaseRepository<TravelPackage> travelPackages)
        {
            _TravelPackages = travelPackages;
        }

        public async Task <ActionResult> Index()
        {
            var travelPackage = await _TravelPackages.GetAll();
            return View("TravelPackageList",travelPackage);
        }

        // GET: TravelPackagesController/Details/5
        public async Task <ActionResult> Details(int id)
        {
            var travelPackage = await _TravelPackages.GetById(id);
            return View("TravelPackageDetails", travelPackage);
        }

        // GET: TravelPackagesController/Create
        public async Task <ActionResult> Create()
        {
            return View("NewTravelPackage");
        }

        // POST: TravelPackagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(TravelPackage travelPackage)
        {
            try
            {
                var Travelpackagetest = _TravelPackages.GetAll().Result.Any(c => c.PackageName == travelPackage.PackageName);
                if (Travelpackagetest)
                {
                    ViewBag.ExistsError = "TravelPackage Name already exists";
                    return View("NewTravelPackage", travelPackage);
                }
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
        public async Task <ActionResult> Edit(int id)
        {
            var travelPackage = await _TravelPackages.GetById(id);
            if (travelPackage == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("EditTravelPackage",travelPackage);
        }

        // POST: TravelPackagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, TravelPackage travelPackage)
        {
            try
            {
                await _TravelPackages.UpdateItem(travelPackage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditTravelPackage");
            }
        }

        // GET: TravelPackagesController/Delete/5
        public async Task <ActionResult> Delete(int id)
        {
            var travelpackage = await _TravelPackages.GetById(id);
            return View("DeleteTravelPackage",travelpackage);
        }

        // POST: TravelPackagesController/Delete/5
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
