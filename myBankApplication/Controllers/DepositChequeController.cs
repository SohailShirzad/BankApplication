using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.Repository;
using myBankApplication.ViewModels;
using System.Net;
using System.Runtime.CompilerServices;

namespace myBankApplication.Controllers
{
    public class DepositChequeController : Controller
    {
        private readonly IDepositChequeRepository _depositChequeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IPhotoService _photoService;

        public DepositChequeController(IDepositChequeRepository depositChequeRepository, IAccountRepository accountRepository, IPhotoService photoService)
        {
            _depositChequeRepository = depositChequeRepository;
            _photoService = photoService;
            _accountRepository = accountRepository;
        }

        [HttpGet("Cheques")]
        public async Task<IActionResult> Index()
        {
            var Cheques = await _depositChequeRepository.GetAll();
            List<IndexChequeViewModel> result = new List<IndexChequeViewModel>();
            foreach (var cheques in Cheques)
            {
                var indexChequeViewModel = new IndexChequeViewModel()
                {
                    Id = cheques.Id,
                   accountNumbber = cheques.AccountNum,
                    Amount = cheques.Amount,
                    Description = cheques.Description,
                    Status = cheques.Status,
                    Date = cheques.Date,
                };

                result.Add(indexChequeViewModel);
            }

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            
            var cheques = await _depositChequeRepository.GetById(id);
            if (cheques == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }
            var acc = await _accountRepository.GetAll();
            var account = acc.Where(a => a.AccountNo == cheques.AccountNum).SingleOrDefault();
            var indexChequeViewModel = new IndexChequeViewModel()
            {
                
                Id = cheques.Id,
                Amount = cheques.Amount,
                Description = cheques.Description,
                Status = cheques.Status,
                Date = cheques.Date,
                accountNumbber = account.AccountNo,
                FrontChequeImage = cheques.FrontChequeImage,
                BackChequeImage = cheques.BackChequeImage,
                
            };
            return View(indexChequeViewModel);
    }



        [HttpGet]

        public async Task<IActionResult> Create()
        {
            var curUserId = HttpContext.User.GetUserId();
            var DepositChequeViewModel = new DepositChequeViewModel 
            { 
                AppUserId = curUserId,
                
            };

            return View(DepositChequeViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(DepositChequeViewModel ChequeVM)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            var curUserId = HttpContext.User.GetUserId();
            var acc = await _accountRepository.GetAll();
            var account = acc.Where(a => a.AppUserId == curUserId).SingleOrDefault();

            var amount = ChequeVM.Amount;
            if (amount > 2000)
            {
                TempData["Error"] = "Amount must be 2000 or less per cheque per day";
                return View(ChequeVM);
            }

            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(ChequeVM.FrontChequeImage);
                var backChequeResult = await _photoService.AddPhotoAsync(ChequeVM.BackChequeImage);

                var depositChequeModel = new DepositChequeModel
                {

                    Amount = ChequeVM.Amount,
                    Description = ChequeVM.Description,
                    FrontChequeImage = result.Url.ToString(),
                    BackChequeImage = backChequeResult.Url.ToString(),
                    AccountNum = account.AccountNo,
                };
                _depositChequeRepository.Add(depositChequeModel);
                ViewData["Success"] = "Transaction has been successful, the amount will be added to your account once admin has approved your cheque.";
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(ChequeVM);
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
