using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class BankController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


    }
}
