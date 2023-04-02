using Microsoft.AspNetCore.Identity;
using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.Net;

namespace myBankApplication.Data
{
    public class Seed
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
                        PhoneNumber = "07961977725",
                        Education = "Bachelor's degree",
                        Occupation = "Software Engineer",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1993 - 04 - 07),
                        Income = 0,
                        CountryOfBirth = "United Kingdom",
                        Nationality = "british",
                        Address = "London",
                        Post_Code = "SSSSSS",
                        Date_Joined = DateTime.Now,
                        UserName = "SohailShirzad",
                        Email = adminUserEmail,
                        Profile_Picture = "https://res.cloudinary.com/dnzmex4h3/image/upload/v1679933742/kzfk2cl5fabhhm8ib671.jpg",
                        Proof_Id = "https://res.cloudinary.com/dnzmex4h3/image/upload/v1679934585/uo0p8hg4olneddtcqmtv.png",
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
                        PhoneNumber = "07961977726",
                        Education = "Bachelor's degree",
                        Occupation = "Software Engineer",
                        Gender = Gender.Male,
                        DateOfBirth = new DateTime(1995 - 04 - 07),
                        Income = 10000,
                        CountryOfBirth = "United Kingdom",
                        Nationality = "british",
                        Address = "London",
                        Post_Code = "SSSSSS",
                        Date_Joined = DateTime.Now,
                        UserName = "HarryKane",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Profile_Picture = "https://res.cloudinary.com/dnzmex4h3/image/upload/v1679953728/harry_aqprbj.png",
                        Proof_Id = "https://res.cloudinary.com/dnzmex4h3/image/upload/v1679934585/uo0p8hg4olneddtcqmtv.png",

                    };
                    await userManager.CreateAsync(newAppUser, "Sohail1234$");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }




            }
        }
    }
}
