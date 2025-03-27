using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
