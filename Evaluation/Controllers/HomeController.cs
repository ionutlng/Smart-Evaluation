using Microsoft.AspNetCore.Mvc;

namespace Evaluation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/Identity/Account/Login");
        }

        public IActionResult Register()
        {
            return Redirect("~/Identity/Account/Register");
        }
    }
}