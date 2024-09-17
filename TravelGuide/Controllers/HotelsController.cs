using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class HotelsController : Controller
    {
        // GET: HotelsController
        private IBaseRepository<Hotel> _hotel;
        public HotelsController(IBaseRepository<Hotel> hotel)
        {
            _hotel = hotel;
        }
        // GET: RoomsController
        public async Task<ActionResult> Index()
        {
            var hotel = await _hotel.GetAll();
            return View("HotelsList", hotel);
        }

        // GET: RoomsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var hotel = await _hotel.GetById(id);
            return View("HotelDetails", hotel);
        }

        // GET: RoomsController/Create
        public async Task<ActionResult> Create()
        {
            return View("NewHotel");
        }

        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Hotel hotel)
        {
            try
            {
                var HotelTest = _hotel.GetAll().Result.Any(c => c.HotelName == hotel.HotelName);

                if (HotelTest)
                {
                    ViewBag.ExistsError = "Hotel Name already exists";
                    return View("NewHotel", hotel);
                }
                await _hotel.AddItem(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NewHotel");
            }
        }

        // GET: RoomsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var hotel = await _hotel.GetById(id);
            if (hotel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("EditHotel",hotel);
        }

        // POST: RoomsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Hotel hotel)
        {
            try
            {
                await _hotel.UpdateItem(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditHotel");
            }
        }

        // GET: RoomsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var hotel = await _hotel.GetById(id);
            return View("DeleteHotel",hotel);
        }

        // POST: RoomsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Hotel hotel)
        {
            try
            {
                await _hotel.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteHotel");
            }
        }
    }
}
