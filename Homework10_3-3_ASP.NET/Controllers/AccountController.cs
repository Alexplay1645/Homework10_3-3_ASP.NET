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
                return View(model); // возвращаем форму с ошибками
            }

            // Здесь могла быть логика сохранения в базу данных
            // _db.Users.Add(new User { ... });
            // _db.SaveChanges();

            ViewBag.Message = "Registration successful!";
            return View("Success");
        }

        // Проверка имени пользователя через Remote
        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckUsername(string username)
        {
            if (username.ToLower() == "admin") // условно считаем, что занято
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
