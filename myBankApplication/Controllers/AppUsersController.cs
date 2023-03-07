using Microsoft.AspNetCore.Mvc;
using myBankApplication.Interfaces;

namespace myBankApplication.Controllers
{
    public class AppUsersController : Controller
    {
        private readonly IAppUsersRepository _customerRepository;

        public AppUsersController(IAppUsersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet("CustomerStatements")]

        public IActionResult AppUserRegistration()
        {
            return View();
        }
        public IActionResult AppUserLogin()
        {
            return View();
        }
        public IActionResult AppUserDepositCheque()
        {
            return View();
        }
        public IActionResult AppUserloan()
        {
            return View();
        }
        public IActionResult AppUserPayment()
        {
            return View();
        }
        public IActionResult AppUserOverdraft()
        {
            return View();
        }
        public IActionResult AppUserStatements()
        {
            return View();
        }
        public IActionResult AppUserTransaction()
        {
            return View();
        }
        public IActionResult AppUserWithdraw()
        {
            return View();
        }
        public IActionResult AppUserDepositCash()
        {
            return View();
        }
        public IActionResult AppUserHome()
        {
            return View();
        }
        public IActionResult AppUserCard()
        {
            return View();
        }
        public IActionResult AppUserDetail()
        {
            return View();
        }
    }
}
