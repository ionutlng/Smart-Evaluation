using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.Controllers
{
    public class ProfesorController : Controller
    {
        [Authorize(Roles = "Profesor")]
        public IActionResult Index()
        {
            return View();
        }
    }
}