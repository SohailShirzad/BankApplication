using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class BankCardModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
