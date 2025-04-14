using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class ProgressTrackingController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult track()
        {
            var trackList = db.ProgressTrackings.ToList();
            return View(trackList);
        }
    }
}
