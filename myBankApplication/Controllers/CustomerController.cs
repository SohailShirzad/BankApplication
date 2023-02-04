using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
