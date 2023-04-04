using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
 
    public class AppUsersController : Controller
    {
        private readonly IAppUsersRepository _customerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPhotoService _photoService;

        public AppUsersController(IAppUsersRepository customerRepository, IHttpContextAccessor httpContextAccessor, IPhotoService photoService )
        {
            _customerRepository = customerRepository;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
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
                        Profile_Picture = user.Profile_Picture
                        
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
                Profile_Picture = user.Profile_Picture,
                Proof_Id = user.Proof_Id
                
            };

            return View(userDetailViewModel);
        }


        public async Task<IActionResult> Balance(string id)
        {
            var userAccounts = await _customerRepository.GetAllUsersAccounts();
            var userTransactions = await _customerRepository.GetAllUsersTransactions();
            var userBankCards = await _customerRepository.GetAllUsersBankCards();
            var userCheques = await _customerRepository.GetAllUsersCheques();

            var user = await _customerRepository.GetUserById(id);
            if (user == null)
            {
                return View("Error");
            }
            
            var appUsersViewModel = new AppUsersViewModel()
            {
                Accounts = userAccounts,
                BankCards = userBankCards,
                Transactions = userTransactions,
                DepositCheque = userCheques,

                Title = user.Title,
                LName = user.LName,
                FName = user.FName,
                MName= user.MName,
                Email = user.Email,
                Nationality = user.Nationality,
                Profile_Picture = user.Profile_Picture,
            };

            return View(appUsersViewModel);
        }


        public IActionResult AppUserPayment()
        {
            return isUserAuthenticated();
        }

        public IActionResult AppUserTransaction()
        {
            return isUserAuthenticated();
        }

        public IActionResult AppUserDepositCash()
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
