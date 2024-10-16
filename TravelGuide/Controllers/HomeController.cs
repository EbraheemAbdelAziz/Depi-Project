using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelGuide.Entiteis.Models;
using TravelGuide.Models;
using TravelGuide.Repositories.Interfaces; // Ensure this is included

namespace TravelGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseRepository<Flight> _flightRepository;
        private readonly IBaseRepository<Hotel> _hotelRepository;
        private readonly IBaseRepository<TravelPackage> _travelPackage;

        public HomeController(ILogger<HomeController> logger, IBaseRepository<Flight> flightRepository, IBaseRepository<Hotel> hotelRepository, IBaseRepository<TravelPackage> travelPackage)
        {
            _logger = logger;
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;
            _travelPackage = travelPackage;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _flightRepository.GetAll(null, new[] { "location" });
            var hotelModel = await _hotelRepository.GetAll(null, new[] { "Location" });
            ViewBag.HotelModel = hotelModel;
            IEnumerable<TravelPackage> travelPackage =await _travelPackage.GetAll(null, new[] { "Destination" });
            ViewBag.TravelPackage= travelPackage;
            return View(flights);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
