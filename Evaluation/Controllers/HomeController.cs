using Microsoft.AspNetCore.Mvc;

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