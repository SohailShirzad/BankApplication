using Microsoft.AspNetCore.Mvc;
using myBankApplication.Data;
using myBankApplication.Models;

namespace myBankApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext myBankApplication;

        public EmployeeController (ApplicationDbContext myBankApplication)
        {
            this.myBankApplication = myBankApplication;
        }


        [HttpGet]
        public IActionResult EmployeeRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddEmployeeModel addEmployeeModel)
        {
            var employee = new EmployeeModel()
            {
                Title = addEmployeeModel.Title,
                FName = addEmployeeModel.FName,
                MName = addEmployeeModel.MName,
                LName = addEmployeeModel.LName,
                Phone_No = addEmployeeModel.Phone_No,
                Education = addEmployeeModel.Education,
                Job_title = addEmployeeModel.Job_title,
                Gender = addEmployeeModel.Gender,
                DateOfBirth = addEmployeeModel.DateOfBirth,
                Income = addEmployeeModel.Income,
                CountryOfBirth = addEmployeeModel.CountryOfBirth,
                Nationality = addEmployeeModel.Nationality,
                Address = addEmployeeModel.Address,
                Post_Code = addEmployeeModel.Post_Code,
                Supervisor = addEmployeeModel.Supervisor,
                Date_Joined = addEmployeeModel.Date_Joined,
                Email = addEmployeeModel.Email,
                Banking_Password = addEmployeeModel.Banking_Password,
                Banking_ConfirmationPassword = addEmployeeModel.Banking_ConfirmationPassword,


            };

            await myBankApplication.Staff.AddAsync(employee);
            await myBankApplication.SaveChangesAsync();
            return RedirectToAction("EmployeeRegistration");
        }
    }
}
