using System.ComponentModel.DataAnnotations;

namespace myBankApplication.Models
{
    public class AppUsersLoginModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
