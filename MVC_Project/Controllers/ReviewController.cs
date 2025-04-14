using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class ReviewController : Controller
    {
        AppDbContext db = new AppDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult review()
        {
            var reviewList = db.Reviews.ToList();
            return View(reviewList);
        }
    }
}
