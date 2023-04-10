using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class EditUserProfileViewModel
    {
        public string? Id { get; set; }

        public string? Title { get; set; }

        public string? FName { get; set; }

        public string? MName { get; set; }

        public string? LName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Post_Code { get; set; }

        public string? EmailAddress { get; set; }


        public string? Profile_PictureURL { get; set; }

        public IFormFile Image { get; set; }

    }
}
