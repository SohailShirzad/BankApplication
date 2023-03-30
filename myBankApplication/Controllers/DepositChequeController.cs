using Microsoft.AspNetCore.Mvc;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;
using System.Net;

namespace myBankApplication.Controllers
{
    public class DepositChequeController : Controller
    {
        private readonly IDepositChequeRepository _depositChequeRepository;
        private readonly IPhotoService _photoService;

        public DepositChequeController(IDepositChequeRepository depositChequeRepository, IPhotoService photoService)
        {
            _depositChequeRepository = depositChequeRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<DepositChequeModel> depositCheques = await _depositChequeRepository.GetAll();
            return View(depositCheques);
        }




        [HttpGet]

        public IActionResult Create()
        {
            var curUserId = HttpContext.User.GetUserId();
            var DepositChequeViewModel = new DepositChequeViewModel { AppUserId = curUserId };

            return View(DepositChequeViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(DepositChequeViewModel ChequeVM)
        {
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
                    AppUserId = ChequeVM.AppUserId,

                };
                _depositChequeRepository.Add(depositChequeModel);
                return RedirectToAction("Balance", "AppUsers");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(ChequeVM);
        }
    }
}
