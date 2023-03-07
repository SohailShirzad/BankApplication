using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using NuGet.Protocol.Core.Types;
using System.Reflection;

namespace myBankApplication.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationRepository _repository;

        public UserAuthenticationController (IUserAuthenticationRepository userAuthenticationRepository)
        {
            _repository = userAuthenticationRepository;
        }

        // For Registation

        public IActionResult AppUserRegistration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(AppUsersRegistrationModel appUsersRegistrationModel)
        {
            if (!ModelState.IsValid)
                return View(appUsersRegistrationModel);
            appUsersRegistrationModel.Role = "user";
            var result = await _repository.RegistationAsync(appUsersRegistrationModel);
            TempData["msg"] = result.StatusMessage;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult AppUserLogin()
        {
            return View();
        }

        //Login check to check if the username and password matches

        [HttpPost]
        public async Task <IActionResult> Login (AppUsersLoginModel appUsersLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(appUsersLoginModel);
            }    

            var result = await _repository.LoginAsync(appUsersLoginModel);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");

            }

            else
            {
                TempData["message"] = result.StatusMessage;
                return RedirectToAction(nameof(appUsersLoginModel));
            }
        }

        
        // Logout 
        [Authorize]

        public async Task<IActionResult> Logout()
        {
            await _repository.LogoutAsync();
            return RedirectToAction(nameof(AppUserLogin));
        }

        // Add admin 

        //public async Task <IActionResult> AdminReg()
        //{
        //    var model = new AppUsersRegistrationModel
        //    {
        //        Title = "Mr",
        //        FName = "Sohail",
        //        LName = "Shirzad",
        //        Education = "Bachelor's degree",
        //        Occupation = "Supervisor of Administrative Support Workers",
        //        Gender = Data.Enum.Gender.Male,
        //        DateOfBirth = DateTime.Now,
        //        Income = 0 - 10000,
        //        CountryOfBirth = "United Kingdom",
        //        Nationality = "British",
        //        Address = "London",
        //        Post_Code = "AAAAAA",
        //        Date_Joined = DateTime.Now,
        //        EmailAddress = "sohail_shirzad@hotmail.com",
        //        Password = "Admin1234$",
        //        ConfirmPassword = "Admin1234$",
        //        //Profile_Picture = "s",
        //        //Proof_Id = "",

        //    };

        //    model.Role = "admin";
        //    var result = await _repository.RegistationAsync(model);
        //    return Ok(result);
        //}
    }
}
