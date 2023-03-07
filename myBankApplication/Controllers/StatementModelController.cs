using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class StatementModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
