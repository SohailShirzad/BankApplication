using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
