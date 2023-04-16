using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;
using System.Runtime.CompilerServices;

namespace myBankApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ApplicationDbContext _dbContext;
         

        public AccountController(IAccountRepository AccountRepositoy, ApplicationDbContext dbContext)
        {
            _accountRepository = AccountRepositoy;
            _dbContext = dbContext;
        }


        public IActionResult Detail()
        {

            return View();
        }

        [HttpGet]

        public IActionResult Create()
        {
          
            var curUserId = HttpContext.User.GetUserId();
            var createAccountViewModel = new CreateAccountViewModel { AppUserId = curUserId };

            return View(createAccountViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateAccountViewModel accountVM)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            if (ModelState.IsValid)
            {
                var account = new AccountModel
                {
                    AccountNo = accountVM.AccountNo,
                    Sort_Code = accountVM.Sort_Code = "07-04-93",
                    AccountType = accountVM.AccountType,
                    Balance = accountVM.Balance,
                    Date_Opened = accountVM.Date_Opened = DateTime.Now,
                    Status = accountVM.Status = Data.Enum.Status.Active,
                    Close_Date = accountVM.Close_Date,
                    AppUserId = accountVM.AppUserId,
        
                };
                _accountRepository.Add(account);
                return RedirectToAction("Balance", "AppUsers");

            }
            else
            {
                ModelState.AddModelError("","Failed to create an account, please try again later.");
            }

            return View(accountVM);
            

        }


        public Boolean isUserAuthenticated()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }



    }
}
