using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using TravelGuide.Repositories.Interfaces;
using TravelGuide.Entiteis.Models;

namespace TravelGuide.Controllers
{
    public class FlightBookingController : Controller
    {
        private readonly IBaseRepository<FlightBooking> _flightBooking;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBaseRepository<Payment> _payments;

        public FlightBookingController(IBaseRepository<FlightBooking> flightBooking, UserManager<AppUser> userManager, IBaseRepository<Payment> payments)
        {
            _flightBooking = flightBooking;
            _userManager = userManager;
            _payments = payments;
        }

        // GET: FlightBookingController
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User); 
            if (currentUser == null)
                return RedirectToAction("Login", "Account");
            var flightBookings = await _flightBooking.GetAll(fb => fb.UserId == currentUser.Id, new[] { "Flight" });
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            if (isAdmin)
            {
                flightBookings = await _flightBooking.GetAll(null, new[] { "Flight" });
            }
            foreach(var flightBooking in flightBookings)
            {
                flightBooking.User = await _userManager.FindByIdAsync(flightBooking.UserId);
            }
            return View("listFlightBookings", flightBookings);
        }

        // GET: FlightBookingController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) 
                return RedirectToAction("Login", "Account");

            var flightBooking = await _flightBooking.GetById(id);

            return View("FlightBookingDetails", flightBooking);
        }

        // GET: FlightBookingController/Create
        public async Task<IActionResult> Create(int FlightId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("Login", "Account");

            var flightBookings = await _flightBooking.GetAll(fb => fb.FlightId == FlightId);
            var reservedSeats = flightBookings.Select(fb => fb.SeatNumber).ToList();
            var availableSeats = Enumerable.Range(1, 30).Except(reservedSeats).ToList();

            var flightBooking = new FlightBooking
            {
                FlightId = FlightId,
                UserId = currentUser.Id 
            };

            ViewBag.AvailableSeats = new SelectList(availableSeats);
            return View("NewFlightBooking", flightBooking);
        }

        // POST: FlightBookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightBooking flightBooking)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");

                flightBooking.UserId = currentUser.Id;
                var flightBookingObj = await _flightBooking.AddItem(flightBooking);
                return RedirectToAction("Create", "Payment", new { type = "flightBooking" , BookingId = flightBookingObj.BookingId });
            }
            catch
            {
                return View("NewFlightBooking");
            }
        }

        // GET: FlightBookingController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("Login", "Account");

            var flightBooking = await _flightBooking.GetById(id);
            var flightBookings = await _flightBooking.GetAll(fb => fb.FlightId == flightBooking.FlightId);
            var reservedSeats = flightBookings.Select(fb => fb.SeatNumber).ToList();
            reservedSeats.Add(flightBooking.SeatNumber);
            var availableSeats = Enumerable.Range(1, 30).Except(reservedSeats).ToList();
            ViewBag.AvailableSeats = new SelectList(availableSeats);

            return View("EditFlightBooking", flightBooking);
        }

        // POST: FlightBookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FlightBooking flightBooking)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");

                flightBooking.UserId = currentUser.Id; 

                await _flightBooking.UpdateItem(flightBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditFlightBooking");
            }
        }

        // GET: FlightBookingController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");

            var flightBooking = await _flightBooking.GetById(id);

            return View("DeleteFlightBooking", flightBooking);
        }

        // POST: FlightBookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, FlightBooking flightBooking)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");
                var payments = await _payments.GetAll(p => p.FlightBookingId == id);
                foreach (var item in payments)
                {
                    await _payments.DeleteItem(item.PaymentId);
                }
                await _flightBooking.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteFlightBooking");
            }
        }

            }
        }
