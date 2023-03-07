using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class BankModelController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


    }
}
