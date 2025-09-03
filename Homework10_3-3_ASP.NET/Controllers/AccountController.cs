using Microsoft.AspNetCore.Mvc;
using ValidationDemo.Models;

namespace ValidationDemo.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Message = "Registration successful!";
            return View("Success");
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckUsername(string username)
        {
            if (username.ToLower() == "admin")
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
