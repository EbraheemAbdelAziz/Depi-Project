using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class PackageBookingController : Controller
    {
        // GET: PackageBookingController
        private IBaseRepository<PackageBooking> _packageBooking;
        private readonly UserManager<AppUser> _userManager;
        private IBaseRepository<TravelPackage> _travelPackage;
        private readonly IBaseRepository<Payment> _payments;
        public PackageBookingController(IBaseRepository<PackageBooking> packageBooking, UserManager<AppUser> userManager, IBaseRepository<TravelPackage> travelPackage, IBaseRepository<Payment> payments)
        {
            _packageBooking = packageBooking;
            _userManager = userManager;
            _travelPackage = travelPackage;
            _payments = payments;
        }

        public async Task <ActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");
            var packageBooking = await _packageBooking.GetAll(fb => fb.UserId == currentUser.Id, new[] { "TravelPackage" });
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            if (isAdmin)
            {
                packageBooking = await _packageBooking.GetAll(null, new[] { "TravelPackage" });
            }
            foreach (var flightBooking in packageBooking)
            {
                flightBooking.User = await _userManager.FindByIdAsync(flightBooking.UserId);
            }
            return View("listPackageBooking",packageBooking);
        }

        // GET: PackageBookingController/Details/5
        public async Task <ActionResult> Details(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");
            var packageBooking = await _packageBooking.GetById(id);
            return View("PackageBookingDetails", packageBooking);
        }

        // GET: PackageBookingController/Create
        public async Task <ActionResult> Create(int PackageId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("Login", "Account");
            var packageBooking = await _packageBooking.GetAll(fb => fb.PackageId == PackageId);
            var reservedSeats = packageBooking.Select(fb => fb.NumberOfGuests).ToList();
            var availableSeats = Enumerable.Range(1, 30).Except(reservedSeats).ToList();

            var packageBookings = new PackageBooking
            {
                PackageId = PackageId,
                UserId = currentUser.Id
            };
            ViewBag.PackageId = PackageId;
            ViewBag.AvailableSeats = new SelectList(availableSeats);
            return View("NewPackageBooking");
        }

        // POST: PackageBookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(PackageBooking packageBooking)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");
                packageBooking.UserId = currentUser.Id;
                var packageBookingObj = await _packageBooking.AddItem(packageBooking);
                return RedirectToAction("Create", "Payment", new { type = "packageBooking", BookingId = packageBookingObj.BookingId });
            }
            catch
            {
                return View("NewPackageBooking");
            }
        }

        // GET: PackageBookingController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("Login", "Account");

            var packageBooking = await _packageBooking.GetById(id);
            var packageBookings = await _packageBooking.GetAll(pb => pb.PackageId == packageBooking.PackageId);
            var reservedGuests = packageBookings.Select(pb => pb.NumberOfGuests).ToList();
            reservedGuests.Add(packageBooking.NumberOfGuests);
            var availableGuests = Enumerable.Range(1, 30).Except(reservedGuests).ToList();
            ViewBag.AvailableGuests = new SelectList(availableGuests);
            return View("EditPackageBooking", packageBooking);
        }

        // POST: PackageBookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, PackageBooking packageBooking)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");

                packageBooking.UserId = currentUser.Id;
                await _packageBooking.UpdateItem(packageBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditPackageBooking");
            }
        }

        // GET: PackageBookingController/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task <ActionResult> Delete(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");
            var packageBooking = await _packageBooking.GetById(id);
            TravelPackage travelPackage =await _travelPackage.GetById((int)packageBooking.PackageId);
            packageBooking.TravelPackage = travelPackage;
            return View("DeletePackageBooking", packageBooking);
        }

        // POST: PackageBookingController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(int id, PackageBooking packageBooking)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");
                var payments = await _payments.GetAll(p=> p.PackageBookingId == id);
                foreach (var item in payments)
                {
                    await _payments.DeleteItem(item.PaymentId);
                }
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
