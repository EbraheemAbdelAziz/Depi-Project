using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using TravelGuide.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TravelGuide.Entiteis.Models;

namespace TravelGuide.Controllers
{
    public class FlightBookingController : Controller
    {
        private readonly IBaseRepository<FlightBooking> _flightBooking;

        public FlightBookingController(IBaseRepository<FlightBooking> flightBooking, IBaseRepository<Flight> flight)
        {
            _flightBooking = flightBooking;
          
        }

        // GET: FlightBookingController
        public async Task<IActionResult> Index()
        {
            var flightBookings = await _flightBooking.GetAll(null, new[] { "Flight" }); ;
            return View("listFlightBookings", flightBookings);
        }

        // GET: FlightBookingController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var flightBooking = await _flightBooking.GetById(id); 

            return View("FlightBookingDetails", flightBooking);
        }

        // GET: FlightBookingController/Create
        public async Task<IActionResult> Create(int FlightId)
        {
            //var flight = await _flight.GetById(FlightId);
            var flightBookings = await _flightBooking.GetAll();
            var reservedSeats = flightBookings
                .Where(fb => fb.FlightId == FlightId)
                .Select(fb => fb.SeatNumber)
                .ToList();
            var availableSeats = Enumerable.Range(1, 30).Except(reservedSeats).ToList();
            var flightBooking = new FlightBooking
            {
                FlightId = FlightId,
                //Flight = flight
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
                await _flightBooking.AddItem(flightBooking);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NewFlightBooking");
            }
        }

        // GET: FlightBookingController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var flightBooking = await _flightBooking.GetById(id);
            var flightBookings = await _flightBooking.GetAll();
            var reservedSeats = flightBookings
                .Where(fb => fb.FlightId == flightBooking.FlightId)
                .Select(fb => fb.SeatNumber)
                .ToList();
            reservedSeats.Append(flightBooking.SeatNumber);
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
            var flightBooking = await _flightBooking.GetById(id) ;  

            return View("DeleteFlightBooking", flightBooking);
        }

        // POST: FlightBookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, FlightBooking flightBooking)
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
