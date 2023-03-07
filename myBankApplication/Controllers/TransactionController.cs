using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class TransactionModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
