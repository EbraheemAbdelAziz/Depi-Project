using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class FlightBookingController : Controller
    {
        IBaseRepository<FlightBooking> _flightBooking;

        public FlightBookingController(IBaseRepository<FlightBooking> flightBooking)
        {
            _flightBooking = flightBooking;
        }

        // GET: FlightBookingController
        public async Task<ActionResult> Index()
        {
            var flightBookings = await _flightBooking.GetAll();
            return View("listFlightBookings",flightBookings);
        }

        // GET: FlightBookingController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var flightBooking = await _flightBooking.GetById(id);
            return View("FlightBookingDetails",flightBooking);
        }

        // GET: FlightBookingController/Create
        public async Task<ActionResult> Create()
        {
            return View("NewFlightBooking");
        }

        // POST: FlightBookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FlightBooking flightBooking)
        {
            try
            {
                await _flightBooking.AddItem(flightBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NewFlightBooking");
            }
        }

        // GET: FlightBookingController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var flightBooking = await _flightBooking.GetById(id);
            return View("EditFlightBooking",flightBooking);
        }

        // POST: FlightBookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, FlightBooking flightBooking)
        {
            try
            {
                await _flightBooking.UpdateItem(flightBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditFlightBooking");
            }
        }

        // GET: FlightBookingController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var flightBooking = await _flightBooking.GetById(id);
            return View("DeleteFlightBooking",flightBooking);
        }

        // POST: FlightBookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, FlightBooking flightBooking)
        {
            try
            {
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
