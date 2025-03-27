using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
