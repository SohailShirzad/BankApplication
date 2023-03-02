using Microsoft.AspNetCore.Mvc;

namespace myBankApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        public IActionResult NewBankAccount()
        {
            return View();
        }
        public IActionResult CustomerLogin()
        {
            return View();
        }
        public IActionResult CustomerDepositCheque()
        {
            return View();
        }
        public IActionResult Customerload()
        {
            return View();
        }
        public IActionResult CustomerPayment()
        {
            return View();
        }
        public IActionResult CustomerOverdraft()
        {
            return View();
        }
        public IActionResult CustomerStatements()
        {
            return View();
        }
        public IActionResult CustomerTransaction()
        {
            return View();
        }
        public IActionResult CustomerWithdraw()
        {
            return View();
        }
        public IActionResult CustomerDepositCash()
        {
            return View();
        }
        public IActionResult CustomerHome()
        {
            return View();
        }
    }
}
