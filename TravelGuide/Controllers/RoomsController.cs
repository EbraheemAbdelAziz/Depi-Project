using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using TravelGuide.Repositories.Interfaces;

using TravelGuide.Entiteis.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelGuide.Controllers

{

    public class RoomsController : Controller

    {

        private IBaseRepository<Room> _room;

        private IBaseRepository<Hotel> _hotel;

        public RoomsController(IBaseRepository<Room> room, IBaseRepository<Hotel> hotel)

        {

            _room = room;

            _hotel = hotel;

        }

        // GET: RoomsController 

        public async Task<ActionResult> Index(int HotelId)

        {

            var room = await _room.GetAll(r=>r.hotelId == HotelId, new[] { "hotel" });

            return View("RoomsList", room);

        }



        // GET: RoomsController/Details/5 

        public async Task<ActionResult> Details(int     id)

        {
            var room = await _room.GetById(id);
            room.hotel = await _hotel.GetById(room.hotelId);
            return View("RoomDetails", room);

        }



        // GET: RoomsController/Create 
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Create()

        {

            var hotel = await _hotel.GetAll();

            var room = new Room { HotelList = hotel.ToList() };

            return View("NewRoom", room);

        }



        // POST: RoomsController/Create 
        [Authorize(Roles = "Admin")]

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Room room)

        {

            try

            {

                var RoomTest = _room.GetAll().Result.Any(c => c.RoomNumber == room.RoomNumber);



                if (RoomTest)

                {

                    ViewBag.ExistsError = "Room Number already exists";

                    return View("NewRoom", room);

                }

                await _room.AddItem(room);

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View("NewRoom");

            }

        }



        // GET: RoomsController/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Edit(int id)

        {
            var room = await _room.GetById(id);
            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var hotel = await _hotel.GetAll();
            room.HotelList = hotel.ToList();
            return View("EditRoom", room);
        }



        // POST: RoomsController/Edit/5 
        [Authorize(Roles = "Admin")]
        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(int id, Room room)

        {
            try

            {
                await _room.UpdateItem(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditRoom");
            }
        }



        // GET: RoomsController/Delete/5 
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)

        {
            var room = await _room.GetById(id);
            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var hotel = await _hotel.GetAll();
            room.HotelList = hotel.ToList();
            return View("DeleteRoom", room);

        }



        // POST: RoomsController/Delete/5 
        [Authorize(Roles = "Admin")]
        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Delete(int id, Room room)

        {

            try

            {

                await _room.DeleteItem(id);

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View("DeleteRoom");

            }

        }

    }

}
