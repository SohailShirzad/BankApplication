﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
    public class BankCardController : Controller
    {
        private readonly IBankCardRepository _bankCardRepository;
        private readonly IAppUsersRepository _appUsersRepository;

        public BankCardController(IBankCardRepository bankCardRepository, IAppUsersRepository appUsersRepository)
        {
            _bankCardRepository = bankCardRepository;
            _appUsersRepository = appUsersRepository;
        }

        [HttpGet("bankCards")]
        public async Task<IActionResult> Detail()
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            var bankCards = await _bankCardRepository.GetAll();
            List<IndexBankCardsViewModel> result = new List<IndexBankCardsViewModel>();
            foreach (var bankCard in bankCards)
            {
                var indexBankCardsVM = new IndexBankCardsViewModel()
                {
                    CardNumber = bankCard.CardNumber,
                    CVVNumber = bankCard.CVVNumber,
                    ValidFrom = bankCard.ValidFrom,
                    ExpiryDate = bankCard.ExpiryDate,
                    Account_Id = bankCard.Account_Id,
                    ContaclessLimit = bankCard.ContaclessLimit,
                    CardPin = bankCard.CardPin,
                };

                result.Add(indexBankCardsVM);
            }

            return View(result);
        }

        public async Task<IActionResult> Index()
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(CreateBankCardViewModel BankCardVM)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            if (ModelState.IsValid)
            {
                var bankCard = new BankCardModel
                {
                    CardNumber = BankCardVM.CardNumber,
                    CVVNumber = BankCardVM.CVVNumber,
                    ExpiryDate = BankCardVM.ValidFrom.AddYears(4),
                    ContaclessLimit = 100,
                    Account_Id = BankCardVM.Account_Id,
                };
                _bankCardRepository.Add(bankCard);
                ViewData["Success"] = "Card has been created successfull";
                return View(BankCardVM);

            }
            else
            {
                ModelState.AddModelError("", "Failed to create a bank card, please try again later.");
            }

            return View(BankCardVM);


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