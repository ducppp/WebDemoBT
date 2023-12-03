using Microsoft.AspNetCore.Mvc;
using WebDemoBT.Models;

namespace WebDemoBT.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName.Contains("admin") && model.Password.Contains("admin"))
                {
                    TempData["Info"] = "Admin";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Fail"] = "Tên đăng nhập hoặc mật khẩu không đúng!";
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Please input field full!");
            }
            Abc();
            return View(model);
        }

        public void Abc()
        {
            var a = 1;
        }
    }
}
