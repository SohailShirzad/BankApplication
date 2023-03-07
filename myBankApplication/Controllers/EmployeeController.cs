using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
