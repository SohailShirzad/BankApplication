using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }



        public async Task<IActionResult> Index()
        {

            var userAccounts = await _dashboardRepository.GetAllUserAccounts();

            var dashboardViewModel = new DashboardViewModel()
            {
                Accounts = userAccounts
            };

            return View(dashboardViewModel);
        }


        public async Task<IActionResult> Home(string id)
        {
            var userTransactions = await _dashboardRepository.GetAllUsersTransactions();
            var dashboardViewModel = new DashboardViewModel()
            {
                Transactions = userTransactions
            };

            return View(dashboardViewModel);

        }

        public IActionResult Admin()
        {

            return View();

        }

        public async Task<IActionResult> CustomerCardDetails()
        {
            var userBankCards = await _dashboardRepository.GetAllUsersBankCards();
            var dashboardViewModel = new DashboardViewModel()
            {
                BankCards = userBankCards,
           
                
            };

            return View(dashboardViewModel);
        }









        // Check if the user is authenicated 
        public IActionResult isUserAuthenticated()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "UserAuthentication");
            return View();
        }
    }
}
