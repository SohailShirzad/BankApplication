using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.Models
{
    public class AppUsersRegistrationModel
    {
        [Required(ErrorMessage = "Please select a title"), MaxLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your first name"), MaxLength(50)]
        [RegularExpression(@"^[0-9A-Za-z] +$", ErrorMessage = "Name cannot contain number or special characters")]
        public string FName { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^[0-9A-Za-z] +$", ErrorMessage = "Name cannot contain number or special characters")]
        public string? MName { get; set; }

        [RegularExpression(@"^[0-9A-Za-z] +$", ErrorMessage = "Name cannot contain number or special characters")]
        [Required(ErrorMessage = "Please enter your Last name"), MaxLength(50)]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please select your education"), MaxLength(200)]
        public string Education { get; set; }

        [Required(ErrorMessage = "Please select your Occupation"), MaxLength(50)]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Please select your Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter your date of Birth"), MaxLength(50)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select your Salary Range"), MaxLength(50)]
        public long Income { get; set; }

        [Required(ErrorMessage = "Please select your Country"), MaxLength(50)]
        public string CountryOfBirth { get; set; }

        [Required(ErrorMessage = "Please select your Nationality"), MaxLength(50)]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter your address"), MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Post Code"), MaxLength(8)]
        public string Post_Code { get; set; }

        public DateTime Date_Joined { get; set; }

        [Required (ErrorMessage = "Please enter your phone number"), MaxLength(20)]
        public string phoneNumber { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage="Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

        public string ? Role { get; set; }

        //[Required(ErrorMessage = "Please Upload profile picture")]
        public byte[]? Profile_Picture { get; set; }
        //[Required(ErrorMessage = "Please upload proof of Id")]
        public byte[]? Proof_Id { get; set; }
    }
}
