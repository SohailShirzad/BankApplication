﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.DependencyInjection;
using myBankApplication.Data;
using myBankApplication.Data.Enum;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;
using NuGet.Protocol.Core.Types;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace myBankApplication.Controllers
{

    public class UserAuthenticationController : Controller
    {
        private readonly SignInManager<AppUsersModel> _signInManager;
        private readonly UserManager<AppUsersModel> _userManager;
        private readonly IAccountRepository _accountRepository;
        private ApplicationDbContext _context;
        private readonly IPhotoService _photoService;

        public UserAuthenticationController(SignInManager<AppUsersModel> signInManager,
                                             UserManager<AppUsersModel> userManager,
                                             ApplicationDbContext dbContext, 
                                             IAccountRepository accountRepository, IPhotoService photoService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountRepository = accountRepository;
            _context = dbContext;
            _photoService = photoService;

        }

        [HttpGet]
        public IActionResult Login()
        {
            var getLogin = new AppUsersLoginModel();
            return View(getLogin);
        }

        //Login check to check if the username and password matches
        
        [HttpPost]
        public async Task<IActionResult> Login(AppUsersLoginModel appUsersLoginModel)
        {

           if (!ModelState.IsValid) return View(appUsersLoginModel);
           
            // check if the user exist
           var user = await _userManager.FindByEmailAsync(appUsersLoginModel.EmailAddress);

            if (user != null)
            {
                //user if found check password

                var checkPassword = await _userManager.CheckPasswordAsync(user, appUsersLoginModel.Password);
                if (checkPassword)
                {
                    // sign in, password is correct 
                    var result = await _signInManager.PasswordSignInAsync(user, appUsersLoginModel.Password, false,  false);
                    if (result.Succeeded)
                    {
                        
                        //Get Role
                        var roles = await _userManager.GetRolesAsync(user);



                        if (roles.Contains("admin"))
                        {
                           return RedirectToAction("Index", "AppUsers");
                        }

                        var acc = await _accountRepository.GetAll();
                        var account = acc.Where(a => a.AppUserId == user.Id).SingleOrDefault();
                        if (account == null && roles.Contains("user"))
                        {
                            return RedirectToAction("Create", "Account");
                        }

                        return RedirectToAction("Balance", "AppUsers");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Password is not correct. Please try again";
                return View(appUsersLoginModel);
            }
            //User not found
            TempData["Error"] = "Email is not correct, please try again";
            return View(appUsersLoginModel);
    }

        // For Registation

        [HttpGet]
        public IActionResult Registration()
        {
            var register = new AppUsersRegistrationModel();
            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(AppUsersRegistrationModel appUsersRegistrationModel)
        {
            if (!ModelState.IsValid) return View(appUsersRegistrationModel);
            var user = await _userManager.FindByEmailAsync(appUsersRegistrationModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use, please use another email address";
                return View(appUsersRegistrationModel);
            }
            var profilePic = await _photoService.AddPhotoAsync(appUsersRegistrationModel.Profile_Picture);
            var proofId = await _photoService.AddPhotoAsync(appUsersRegistrationModel.Profile_Picture);

            var newAppUser = new AppUsersModel()
            {
                Title = appUsersRegistrationModel.Title,
                FName = appUsersRegistrationModel.FName,
                MName = appUsersRegistrationModel.MName,
                LName = appUsersRegistrationModel.LName,
                PhoneNumber = appUsersRegistrationModel.PhoneNumber,
                Education = appUsersRegistrationModel.Education,
                Occupation = appUsersRegistrationModel.Occupation,
                Gender = appUsersRegistrationModel.Gender,
                DateOfBirth = appUsersRegistrationModel.DateOfBirth,
                Income = appUsersRegistrationModel.Income,
                CountryOfBirth = appUsersRegistrationModel.CountryOfBirth,
                Nationality = appUsersRegistrationModel.Nationality,
                Address = appUsersRegistrationModel.Address,
                Post_Code = appUsersRegistrationModel.Post_Code,
                Date_Joined = appUsersRegistrationModel.Date_Joined = DateTime.Now,
                Email = appUsersRegistrationModel.EmailAddress,
                UserName = appUsersRegistrationModel.EmailAddress,
                Profile_Picture = profilePic.Url.ToString(),
                Proof_Id = proofId.Url.ToString(),

            };
            var newAppUserResponse = await _userManager.CreateAsync(newAppUser, appUsersRegistrationModel.Password);
            if (newAppUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            ViewData["Success"] = "You have successfully registered with us";
            return View();
         }



        // Logout 
        [HttpGet]

        public async Task<IActionResult> Logout()
        {
         
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "UserAuthentication");
        }

        // Add admin 

       
            


        
        
    }
}
