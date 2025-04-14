using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class SessionController : Controller
    {
        AppDbContext db = new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult session()
        {
            var sessionList = db.Sessions.ToList();
            return View(sessionList);
        }
    }
}
