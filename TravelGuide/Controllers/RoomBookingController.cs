using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class RoomBookingController : Controller
	{
        private readonly IBaseRepository<RoomBooking> _roomBooking;
		private UserManager<AppUser> _userManager;
		private readonly IBaseRepository<Hotel> _hotel;
		private readonly IBaseRepository<Room> _room;
		private readonly IBaseRepository<Payment> _payments;
        public RoomBookingController(IBaseRepository<RoomBooking> roomBooking, UserManager<AppUser> userManager, IBaseRepository<Hotel> hotel, IBaseRepository<Room> room, IBaseRepository<Payment> payments)
        {
            _roomBooking = roomBooking;
            _userManager = userManager;
            _hotel = hotel;
            _room = room;
            _payments = payments;
        }
        // GET: RoomBookingController
        public async Task<ActionResult> Index()
		{
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");
            var roomBookings = await _roomBooking.GetAll(fb => fb.UserId == currentUser.Id, new[] { "Room", "Hotel" });
            bool isAdmin = await _userManager.IsInRoleAsync(currentUser, "Admin");
            if (isAdmin)
            {
                roomBookings = await _roomBooking.GetAll(rb => rb.UserId == currentUser.Id, new[] { "Room", "Hotel" });
            }
            foreach (var item in roomBookings)
            {
                item.User = await _userManager.FindByIdAsync(item.UserId);
            }
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
		public async Task<ActionResult> Create(string RoomId)
		{
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");
            var roomBooking = new RoomBooking();
			roomBooking.RoomId = int.Parse(RoomId);
			roomBooking.HotelId = _room.GetById(int.Parse(RoomId)).Result.hotelId;
            return View("NewRoomBooking", roomBooking);
		}

		// POST: RoomBookingController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(RoomBooking roomBooking)
		{
			try
			{
                roomBooking.BookingDate = DateTime.Now;
                roomBooking.UserId = _userManager.GetUserAsync(User).Result.Id;
                var BookingObj = await _roomBooking.AddItem(roomBooking);
                return RedirectToAction("Create", "Payment", new { type = "roomBooking", BookingId = BookingObj.BookingId });
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
		{
            var roomBooking = await _roomBooking.GetById(id);
            if (roomBooking == null)
            {
                return RedirectToAction(nameof(Index));
            }
			roomBooking.Hotel = await _hotel.GetById(roomBooking.HotelId);
			roomBooking.Room = await _room .GetById(roomBooking.RoomId);
            return View("DeleteRoomBooking",roomBooking);
		}

        // POST: RoomBookingController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, RoomBooking roomBooking)
		{
			try
			{
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return RedirectToAction("Login", "Account");
                var payments = await _payments.GetAll(p => p.RoomBookingId == id);
                foreach (var item in payments)
                {
                    await _payments.DeleteItem(item.PaymentId);
                }
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
