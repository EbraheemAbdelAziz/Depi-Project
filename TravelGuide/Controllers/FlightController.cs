using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class FlightController : Controller
    {
        private readonly IBaseRepository<Flight> _flight;
        private IUploadFile _uploadFile;
        private readonly IBaseRepository<Location> _location;
        public FlightController(IBaseRepository<Flight> flight, IUploadFile uploadFile, IBaseRepository<Location> location)
        {
            _flight = flight;
            _uploadFile = uploadFile;
            _location = location;
        }

        // GET: FlightController
        public async Task<ActionResult> Index()
        {
            var flights = await _flight.GetAll(null, new[] { "location" });
            return View("FlightsList", flights);
        }

        // GET: FlightController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var flight = await _flight.GetById(id);
            flight.location = await _location.GetById(flight.LocationId);
            return View("FlightDetails", flight);
        }

        // GET: FlightController/Create
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            var locations = await _location.GetAll();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName", "ImageUrl");
            return View("NewFlight");
        }

        // POST: FlightController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Flight flight)
        {
            try
            {
                await _flight.AddItem(flight);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var locations = await _location.GetAll();
                ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName", "ImageUrl");
                return View("NewFlight");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            var flight = await _flight.GetById(id);
            if (flight == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var locations = await _location.GetAll();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName", flight.LocationId);
            return View("EditFlight", flight);
        }
        // POST: FlightController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Flight flight)
        {
            try
            {

                await _flight.UpdateItem(flight);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditFlight", flight);
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: FlightController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var flight = await _flight.GetById(id);
            if (flight == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var locations = await _location.GetAll();
            ViewBag.Locations = new SelectList(locations, "LocationId", "LocationName", flight.LocationId);
            return View("DeleteFlight", flight);
        }

        // POST: FlightController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Flight flight)
        {
            try
            {
                await _flight.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
