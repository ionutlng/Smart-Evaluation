using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.Controllers
{
    public class ProfesorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}