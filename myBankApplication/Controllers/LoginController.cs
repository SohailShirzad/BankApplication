using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Signout()
        {
            return View();
        }
    }
}
