using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class RoomBookingController : Controller
	{
        private readonly IBaseRepository<RoomBooking> _roomBooking;

        public RoomBookingController(IBaseRepository<RoomBooking> roomBooking)
        {
            _roomBooking = roomBooking;
        }
        // GET: RoomBookingController
        public async Task<ActionResult> Index()
		{
			var roomBookings = await _roomBooking.GetAll();
			return View("RoomsBookingList", roomBookings);
		}

		// GET: RoomBookingController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var roomBooking = _roomBooking.GetById(id);
            if (roomBooking == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("RoomBookingDetails", roomBooking);
		}

		// GET: RoomBookingController/Create
		public async Task<ActionResult> Create()
		{
			return View("NewRoomBooking");
		}

		// POST: RoomBookingController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(RoomBooking roomBooking)
		{
			try
			{
				await _roomBooking.AddItem(roomBooking);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
                return View("NewRoomBooking");
            }
		}

		// GET: RoomBookingController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var roomBooking = await _roomBooking.GetById(id);
            if (roomBooking == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("EditRoomBooking", roomBooking);
		}

		// POST: RoomBookingController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, RoomBooking roomBooking)
		{
			try
			{
				await _roomBooking.UpdateItem(roomBooking);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
                return View("EditRoomBooking");
			}
		}

		// GET: RoomBookingController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
            var roomBooking = await _roomBooking.GetById(id);
            if (roomBooking == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("DeleteRoomBooking");
		}

		// POST: RoomBookingController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, RoomBooking roomBooking)
		{
			try
			{
				await _roomBooking.DeleteItem(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View("DeleteRoomBooking");
			}
		}
	}
}
