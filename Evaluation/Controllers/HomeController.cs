using Microsoft.AspNetCore.Mvc;

using Microsoft.Owin.Security;
using Evaluation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Evaluation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
    }
}