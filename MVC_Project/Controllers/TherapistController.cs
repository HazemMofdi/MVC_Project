using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;

namespace MVC_Project.Controllers
{
    public class TherapistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
