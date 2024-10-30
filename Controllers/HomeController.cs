using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TMSApp.Data;
using TMSApp.Models;

namespace TMSApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var totalVehicles = _context.Vehicles.Count();
             
            var recentMaintenance = _context.MaintenanceRecords
                .OrderByDescending(m => m.Date)
                .Include(m => m.Vehicle)
                .Take(5)
                .ToList();
             
            var upcomingMaintenance = _context.MaintenanceRecords
                .Where(m => m.Date >= DateTime.Today && m.Date <= DateTime.Today.AddDays(30))
                .Include(m => m.Vehicle)
                .ToList();

            var overviewModel = new HomeOverviewViewModel
            {
                TotalVehicles = totalVehicles,
                RecentMaintenanceRecords = recentMaintenance,
                UpcomingMaintenanceRecords = upcomingMaintenance
            };

            return View(overviewModel);
        }
         

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
