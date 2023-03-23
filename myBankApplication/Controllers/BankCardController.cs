using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class BankCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
