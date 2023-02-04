using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class SupervisorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
