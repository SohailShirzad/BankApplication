using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using myBankApplication.Data;
using myBankApplication.Data.Enum;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;
using NuGet.Protocol.Core.Types;
using System.Net;
using System.Reflection;


namespace myBankApplication.Controllers
{
    
    public class UserAuthenticationController : Controller
    {
        private readonly SignInManager<AppUsersModel> _signInManager;
        private readonly UserManager<AppUsersModel> _userManager;
        private ApplicationDbContext _context;

        public UserAuthenticationController( SignInManager<AppUsersModel> signInManager,
                                             UserManager<AppUsersModel> userManager,
                                             ApplicationDbContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = dbContext;
            
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
                    var result = await _signInManager.PasswordSignInAsync(user, appUsersLoginModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("AppUserHome", "AppUsers");
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
                Date_Joined = appUsersRegistrationModel.Date_Joined,
                Email = appUsersRegistrationModel.EmailAddress,
                UserName = appUsersRegistrationModel.EmailAddress,
                Profile_Picture = appUsersRegistrationModel.Profile_Picture,
                Proof_Id = appUsersRegistrationModel.Proof_Id,

            };

            var newAppUserResponse = await _userManager.CreateAsync(newAppUser, appUsersRegistrationModel.Password);
            if (newAppUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newAppUser, UserRoles.User);

            return RedirectToAction("AppUserHome", "AppUsers");

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
