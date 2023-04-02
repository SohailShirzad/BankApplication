using Microsoft.AspNetCore.Mvc;
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
        private readonly ApplicationDbContext _applicationDbContext;

        public BankCardController(IBankCardRepository bankCardRepository, ApplicationDbContext applicationDbContext)
        {
            _bankCardRepository = bankCardRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Detail()
        {
            IEnumerable<BankCardModel> bankCards = await _bankCardRepository.GetAll();
            return View(bankCards);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(CreateBankCardViewModel BankCardVM)
        {
            if (ModelState.IsValid)
            {
                var bankCard = new BankCardModel
                {
                    CardNumber = BankCardVM.CardNumber,
                    CVVNumber = BankCardVM.CVVNumber,
                    ExpiryDate = BankCardVM.ExpiryDate,
                    ContaclessLimit = BankCardVM.ContaclessLimit,
                    Account_Id = BankCardVM.Account_Id,
                    AppUserId = BankCardVM.AppUserId,
                };
                _bankCardRepository.Add(bankCard);
                return RedirectToAction("Balance", "AppUsers");

            }
            else
            {
                ModelState.AddModelError("", "Failed to create an account, please try again later.");
            }

            return View(BankCardVM);


        }
    }
}
