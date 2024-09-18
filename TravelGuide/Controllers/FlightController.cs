using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class FlightController : Controller
    {
        private readonly IBaseRepository<Flight> _flight;

        public FlightController(IBaseRepository<Flight> flight)
        {
            _flight = flight;
        }

        // GET: FlightController
        public async Task<ActionResult> Index()
        {
            var flights = await _flight.GetAll();
            return View("FlightsList",flights);
        }

        // GET: FlightController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var flight = await _flight.GetById(id);
            return View("FlightDetails",flight);
        }

        // GET: FlightController/Create
        public async Task<ActionResult> Create()
        {
            return View("NewFlight");
        }

        // POST: FlightController/Create
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
                return View("NewFlight");
            }
        }

        // GET: FlightController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var flight =await _flight.GetById(id);
            if (flight == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("EditFlight",flight);
        }

        // POST: FlightController/Edit/5
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
                return View("EditFlight");
            }
        }

        // GET: FlightController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var flight = await _flight.GetById(id);
            if (flight == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("DeleteFlight",flight);
        }

        // POST: FlightController/Delete/5
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
