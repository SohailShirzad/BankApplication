using Microsoft.AspNetCore.Mvc;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
    public class BankCardController : Controller
    {
        private readonly IBankCardRepository _bankCardRepository;

        public BankCardController(IBankCardRepository bankCardRepository)
        {
            _bankCardRepository = bankCardRepository;
        }

        public async Task<IActionResult> Detail()
        {
            IEnumerable<BankCardModel> bankCards = await _bankCardRepository.GetAll();
            return View(bankCards);
        }

        public IActionResult Index()
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

                    ExpiryDate = BankCardVM.ExpiryDate,
                    ContaclessLimit = BankCardVM.ContaclessLimit,
                    Account_Id = BankCardVM.Account_Id,
                    AppUserId = BankCardVM.AppUserId,
                };
                _bankCardRepository.Add(bankCard);
                return RedirectToAction("AppUserHome", "AppUsers");

            }
            else
            {
                ModelState.AddModelError("", "Failed to create an account, please try again later.");
            }

            return View(BankCardVM);


        }
    }
}
