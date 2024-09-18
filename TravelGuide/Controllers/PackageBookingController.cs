using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class PackageBookingController : Controller
    {
        // GET: PackageBookingController
        private IBaseRepository<PackageBooking> _packageBooking;

        public PackageBookingController(IBaseRepository<PackageBooking> packageBooking)
        {
            _packageBooking = packageBooking;
        }

        public async Task <ActionResult> Index()
        {
            var packageBooking = await _packageBooking.GetAll();
            return View("listPackageBooking",packageBooking);
        }

        // GET: PackageBookingController/Details/5
        public async Task <ActionResult> Details(int id)
        {
            var packageBooking = await _packageBooking.GetById(id);
            return View("PackageBookingDetails", packageBooking);
        }

        // GET: PackageBookingController/Create
        public async Task <ActionResult> Create()
        {
            return View("NewPackageBooking");
        }

        // POST: PackageBookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(PackageBooking packageBooking)
        {
            try
            {
                await _packageBooking.AddItem(packageBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NewPackageBooking");
            }
        }

        // GET: PackageBookingController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var packageBooking = await _packageBooking.GetById(id);
            return View("EditPackageBooking", packageBooking);
        }

        // POST: PackageBookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, PackageBooking packageBooking)
        {
            try
            {
                await _packageBooking.UpdateItem(packageBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditPackageBooking");
            }
        }

        // GET: PackageBookingController/Delete/5
        public async Task <ActionResult> Delete(int id)
        {
            var packageBooking = await _packageBooking.GetById(id);
            return View("DeletePackageBooking", packageBooking);
        }

        // POST: PackageBookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(int id, PackageBooking packageBooking)
        {
            try
            {
                await _packageBooking.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeletePackageBooking");
            }
        }
    }
}
