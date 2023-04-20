﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IPhotoService _photoService;
        private readonly ApplicationDbContext _context;

        public DepositChequeController(IDepositChequeRepository depositChequeRepository, IPhotoService photoService, ApplicationDbContext context)
        {
            _depositChequeRepository = depositChequeRepository;
            _photoService = photoService;
            _context = context; 
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
            var cheques = await _depositChequeRepository.GetByIdAsync(id);
            if (cheques == null)
            {
                return RedirectToAction("Index", "AppUsers");
            }
            var acc = await _context.Accounts.ToListAsync();
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

            var acc = await _context.Accounts.ToListAsync();
            var account = acc.Where(a => a.AppUserId == curUserId).SingleOrDefault();

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
                return RedirectToAction("Balance", "AppUsers");
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
