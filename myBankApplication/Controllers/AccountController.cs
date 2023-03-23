﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
         

        public AccountController(IAccountRepository AccountRepositoy)
        {
            _accountRepository = AccountRepositoy;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AccountModel> accounts = await _accountRepository.GetAll();
            return View(accounts);
        }

        public async Task<IActionResult> Detail(int id)
        {
            AccountModel accountModel = await _accountRepository.getByIdAsync(id);
            return View(accountModel);
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
            if (ModelState.IsValid)
            {
                var account = new AccountModel
                {
                    
                    Sort_Code = accountVM.Sort_Code,
                    AccountType = accountVM.AccountType,
                    Balance = accountVM.Balance,
                    Date_Opened = accountVM.Date_Opened = DateTime.Now,
                    Status = accountVM.Status,
                    Close_Date = accountVM.Close_Date,
                    AppUserId = accountVM.AppUserId,
                };
                _accountRepository.Add(account);
                return RedirectToAction("AppUserHome", "AppUsers");

            }
            else
            {
                ModelState.AddModelError("","Failed to create an account, please try again later.");
            }

            return View(accountVM);
            

        }

    }
}
