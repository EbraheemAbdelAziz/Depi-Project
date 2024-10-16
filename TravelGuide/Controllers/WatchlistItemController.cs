using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class WatchlistItemController : Controller
    {
        private readonly IBaseRepository<WatchlistItem> _WatchlistItem;
        private readonly IBaseRepository<Flight> _flight;
        private readonly IBaseRepository<Room> _room;
        private readonly UserManager<AppUser> _userManager;

        public WatchlistItemController(IBaseRepository<WatchlistItem> watchlistItem, UserManager<AppUser> userManager, IBaseRepository<Flight> flight, IBaseRepository<Room> room)
        {
            _WatchlistItem = watchlistItem;
            _userManager = userManager;
            _flight = flight;
            _room = room;
        }

        // GET: WatchlistItemController
        public async Task<ActionResult> Index()
        {
            var watchList = await _WatchlistItem.GetAll();
            return View("WatchlistList", watchList);
        }

        // GET: WatchlistItemController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var watchList = await _WatchlistItem.GetById(id);
            return View("WatchlistDetails", watchList);
        }

        // POST: WatchlistItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int ItemId, string ItemType,string image, string name)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null)
                    return RedirectToAction("Login", "Account");
                var watchlist = new WatchlistItem()
                {
                    ItemID = ItemId,
                    ItemType = ItemType,
                    UserId = currentUser.Id,
                    Image = image,
                    Name = name

                };
                await _WatchlistItem.AddItem(watchlist);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NewWatchlist");
            }
        }

        // POST: WatchlistItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _WatchlistItem.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteWatchlist");
            }
        }
    }
}
