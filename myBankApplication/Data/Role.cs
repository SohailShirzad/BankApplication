using Microsoft.AspNetCore.Identity;
using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.Net;

namespace myBankApplication.Data
{
    public class Role
    {
        public static async Task UsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Bank.Any())
                {
                    context.Bank.AddRange(new List<BankModel>()
                    {
                        new BankModel()
                        {
                            BankName = "Serena Bank",
                            Bank_Address = "18 Ivinghoe Close, WD259SX",
                            Year_Opened = DateTime.Now
                        }
                    });
                    context.SaveChanges();
                }
            



                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUsersModel>>();
                string adminUserEmail = "sohail_shirzad@hotmail.com";

                var admin = await userManager.FindByEmailAsync(adminUserEmail);
                if (admin == null)
                {
                    var newAdmin = new AppUsersModel()
                    {
                        Title = "Mr",
                        FName = "Sohail",
                        LName = "Shirzad",
                        Education = "Bachelor's degree",
                        Occupation = "Software Engineer",
                        Gender = Gender.Male,
                        DateOfBirth = DateTime.Now,
                        Income = 0,
                        CountryOfBirth = "United Kingdom",
                        Nationality = "British Citizen",
                        Address = "London",
                        Post_Code = "SSSSSS",
                        Date_Joined = DateTime.Now,
                        UserName = "SohailShirzad",
                        Email = adminUserEmail,
                        EmailConfirmed = true,


                    };
                    await userManager.CreateAsync(newAdmin, "Sohail1234$");
                    await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }

                string appUserEmail = "as19adj@herts.ac.uk";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUsersModel()
                    {
                        Title = "Mr",
                        FName = "Harry",
                        LName = "Kane",
                        Education = "Bachelor's degree",
                        Occupation = "Software Engineer",
                        Gender = Gender.Male,
                        DateOfBirth = DateTime.Now,
                        Income = 10000,
                        CountryOfBirth = "United Kingdom",
                        Nationality = "British Citizen",
                        Address = "London",
                        Post_Code = "SSSSSS",
                        Date_Joined = DateTime.Now,
                        UserName = "HarryKane",
                        Email = appUserEmail,
                        EmailConfirmed = true,

                    };
                    await userManager.CreateAsync(newAppUser, "Sohail1234$");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                

                

            }
        }
    }
}
