using Microsoft.AspNetCore.Mvc;

namespace Evaluation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            switch (User.Identity.IsAuthenticated)
            {
                case false:
                    return Redirect("~/Identity/Account/Login");
                default:
                    return User.IsInRole("Profesor") ? Redirect("Profesor/Index") : Redirect("Students/LogIn");
            }
        }


        public IActionResult Register()
        {
            return Redirect("~/Identity/Account/Register");
        }
    }
}