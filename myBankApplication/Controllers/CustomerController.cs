using Microsoft.AspNetCore.Mvc;
using myBankApplication.Interfaces;

namespace myBankApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
