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

        public HomeController(ILogger<HomeController> logger, IBaseRepository<Flight> flightRepository)
        {
            _logger = logger;
            _flightRepository = flightRepository;
        }

        public async Task<IActionResult> Index()
        {
            var flights = await _flightRepository.GetAll(null, new[] { "location" }); 
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
