using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelGuide.Entiteis.Models;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide.Controllers
{
    public class WatchlistItemController : Controller
    {
        IBaseRepository<WatchlistItem> _WatchlistItem;

        public WatchlistItemController(IBaseRepository<WatchlistItem> watchlistItem)
        {
            _WatchlistItem = watchlistItem;
        }

        // GET: WatchlistItemController
        public async Task<ActionResult> Index()
        {
            var WatchList = await _WatchlistItem.GetAll();
            return View("WatchlistList", WatchList);
        }

        // GET: WatchlistItemController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var WatchList = await _WatchlistItem.GetById(id);
            return View("WatchlistDetails", WatchList);
        }

        // GET: WatchlistItemController/Create
        public async Task<ActionResult> Create()
        {
            return View("NewWatchlist");
        }

        // POST: WatchlistItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(WatchlistItem watchlist)
        {
            try
            {
                await _WatchlistItem.AddItem(watchlist);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("NewWatchlist");
            }
        }

        // GET: WatchlistItemController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var watchlist = await _WatchlistItem.GetById(id);
            if (watchlist == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("EditWatchlist", watchlist);
        }

        // POST: WatchlistItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, WatchlistItem watchlist)
        {
            try
            {
                await _WatchlistItem.UpdateItem(watchlist);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditWatchlist");
            }
        }

        // GET: WatchlistItemController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var watchlist = await _WatchlistItem.GetById(id);
            if (watchlist == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("DeleteWatchlist", watchlist);
        }


        // POST: WatchlistItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,WatchlistItem watchlist)
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
