using Microsoft.AspNetCore.Identity;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using System.Reflection;
using System.Security.Claims;

namespace myBankApplication.Repository
{
    public class BankUserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly SignInManager<AppUsersModel> signInManager;
        private readonly UserManager<AppUsersModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public BankUserAuthenticationRepository(RoleManager<IdentityRole> roleManager,
                                             SignInManager<AppUsersModel> signInManager,
                                             UserManager<AppUsersModel> userManager)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<StatusModel> LoginAsync(AppUsersLoginModel appUsersLoginModel)
        {
            var status = new StatusModel();
            var userExists = await userManager.FindByEmailAsync(appUsersLoginModel.EmailAddress);
            if (userExists == null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "Email Address does not exist";
                return status;
            }

            //Password match 
            if (!await userManager.CheckPasswordAsync(userExists, appUsersLoginModel.Password))
            {
                status.StatusCode=0;
                status.StatusMessage = "Invali password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync
                (userExists, appUsersLoginModel.Password, false, true);
            if (signInResult.Succeeded)
            {
                // add roles
                var userRoles = await userManager.GetRolesAsync(userExists);
                var userClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userExists.Email)
                };

                foreach (var userRole in userRoles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.StatusMessage = "You have Logged in Successfully";
                return status;
            }

            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User locked out";
                return status;
            }
            else
            {
                status.StatusCode = 0;
                status.StatusMessage = "There is an error while logging in into the application";
                return status;
            }

        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<StatusModel> RegistationAsync(AppUsersRegistrationModel appUsersRegistrationModel)
        {
            var status = new StatusModel();
            var UserExists = await userManager.FindByEmailAsync(appUsersRegistrationModel.EmailAddress);
            if (UserExists != null)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User already exists";
                return status;
            }

            AppUsersModel appUsers = new AppUsersModel()
            {
                //SecurityStamp = Guid.NewGuid().ToString(),
                Title = appUsersRegistrationModel.Title,
                FName = appUsersRegistrationModel.FName,
                MName = appUsersRegistrationModel.MName,
                LName = appUsersRegistrationModel.LName,
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
                Profile_Picture = appUsersRegistrationModel.Profile_Picture,
                Proof_Id = appUsersRegistrationModel.Proof_Id,

            };

            var result = await userManager.CreateAsync(appUsers, appUsersRegistrationModel.Password);
            if(result.Succeeded)
            {
                status.StatusCode = 0;
                status.StatusMessage = "User creatinon faild";
                return status;
            }

            // Roles for users

            if (!await roleManager.RoleExistsAsync(appUsersRegistrationModel.Role))
                await roleManager.CreateAsync(new IdentityRole(appUsersRegistrationModel.Role));

            if (!await roleManager.RoleExistsAsync(appUsersRegistrationModel.Role))
            {
                await userManager.AddToRoleAsync(appUsers, appUsersRegistrationModel.Role);
            }

            status.StatusCode = 1;
            status.StatusMessage = "You have successfully registered";
            return status;

        }
    }
}
