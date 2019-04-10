using Evaluation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Evaluation.Controllers
{
    public class StudentsController : Controller
    {

        private readonly EvaluationDBContext _context;

        public StudentsController(EvaluationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        
       /* public async Task<ActionResult> Create( Student student)
        {
            bool status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                var isExist = emailExist(student.studUsername);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(student);
                }

                //student.activationCode = System.Guid.NewGuid();

                student.studPassword = Services.Crypto.Hash(student.studPassword);
                student.confirmPassword = Services.Crypto.Hash(student.confirmPassword);

               // student.emailVerified = false;

                string link =  HttpContext.Request.GetEncodedUrl().ToString().Replace(HttpContext.Request.Path,"/Students/Verify/");

                 _context.Add(student);
                await _context.SaveChangesAsync();

               // Services.SendEmail.SendVerificationEmail(student.studUsername, student.activationCode.ToString(), link);
                message = "Registration succes " + student.studUsername;
                    status = true;
                }
            else
            {
                message = "Invalid request";
            }

            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(student);
        }*/

        [HttpGet]
       /* public ActionResult Verify(string id)
        {
            bool Status = false;

           // Student v = _context.Student.Where(a => a.activationCode == new System.Guid(id)).FirstOrDefault();
           if (v != null)
            {
              //  v.emailVerified = true;
                _context.SaveChanges();
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invalid Request";
            }

            ViewBag.Status = Status;
            return View();
        }*/

        // GET: Students
       /* public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }
        */

        /*GET: Students/Create
        public IActionResult Create()
        {
            ViewData["sId"] = new SelectList(_context.Set<Student>(), "sId", "studPassword");

            return View();

        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.sId == id);
        }

        [NonAction]
        public bool emailExist(string email)
        {
            var v = _context.Student.Where(a => a.studUsername == email).FirstOrDefault();
            return v != null;
            
        }*/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
       /* public ActionResult Login(StudentLogIn login, string ReturnUrl = "")
        {
            string message = "";

            Student v = _context.Student.Where(a => a.studUsername == login.Email).FirstOrDefault();

                if (v != null)
                {
                    if (true == false)
                    {
                        ViewBag.Message = "Please verify your email first";
                        return View();
                    }

                    if (string.Compare(Services.Crypto.Hash(login.Password), v.studPassword) == 0)
                    {
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Students");
                        }
                    }
                }
                    else
                    {
                    message = "Invalid credential provided";
                    }
            
            ViewBag.Message = message;
            return View();
        }*/

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            SignOut();
            return RedirectToAction("Login", "Students");
        }
    }
}
