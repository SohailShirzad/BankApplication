using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
