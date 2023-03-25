using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using myBankApplication.Interfaces;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
 
    public class AppUsersController : Controller
    {
        private readonly IAppUsersRepository _customerRepository;

        public AppUsersController(IAppUsersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _customerRepository.GetAll();
            List<AppUsersViewModel> result = new List<AppUsersViewModel>();
            foreach (var user in users)
            {
                {
                    var appUserViewModel = new AppUsersViewModel()
                    {
                        Id = user.Id,
                        FName = user.FName,
                        MName = user.MName,
                        LName = user.LName,
                        Accounts = user.Accounts,
                        Gender = user.Gender,
                        Email = user.Email,
                    };
                    result.Add(appUserViewModel);
                }
                
            }
            return View(result);
        }


        //Details
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _customerRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                FName = user.FName,
                MName = user.MName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                CountryOfBirth = user.CountryOfBirth,
                Nationality = user.Nationality,
                Income = user.Income,
                Occupation = user.Occupation,
                Address = user.Address,
                Post_Code = user.Post_Code,
                Date_Joined = user.Date_Joined,
                Email = user.Email,
            };

            return View(userDetailViewModel);
        }

        public IActionResult AppUserDepositCheque()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserloan()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserPayment()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserOverdraft()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserStatements()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserTransaction()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserWithdraw()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserDepositCash()
        {
            return isUserAuthenticated();
        }
        
        public IActionResult AppUserHome()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserCard()
        {
            return isUserAuthenticated();
        }
        public IActionResult AppUserDetail()
        {
            return isUserAuthenticated();
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
