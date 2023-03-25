using Microsoft.AspNetCore.Mvc;
using myBankApplication.Data;
using myBankApplication.Interfaces;
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





        // Check if the user is authenicated 
        public IActionResult isUserAuthenticated()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "UserAuthentication");
            return View();
        }
    }
}
