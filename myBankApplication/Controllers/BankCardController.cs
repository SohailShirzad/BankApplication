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

        [HttpGet("bankCards")]
        public async Task<IActionResult> Detail()
        {
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
                    AppUserId = bankCard.AppUserId,
                    ContaclessLimit = bankCard.ContaclessLimit,
                    CardPin = bankCard.CardPin,
                };

                result.Add(indexBankCardsVM);
            }

            return View(result);
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
                return RedirectToAction("Admin", "Dashboard");

            }
            else
            {
                ModelState.AddModelError("", "Failed to create an account, please try again later.");
            }

            return View(BankCardVM);


        }
    }
}
