using Microsoft.AspNetCore.Identity;
using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace myBankApplication.Models
{
    public class EmployeeModel : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Employee_Id { get; set; }

        [Required(ErrorMessage = "Please select a title"), MaxLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your first name"), MaxLength(50)]
        public string FName { get; set; }

        [MaxLength(50)]
        public string MName { get; set; }



        [Required(ErrorMessage = "Please enter your Last name"), MaxLength(50)]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number"), MaxLength(15)]
        public string Phone_No { get; set; }

        
        [Required(ErrorMessage = "Please select your education"), MaxLength(80)]
        public string Education { get; set; }

        [Required(ErrorMessage = "Please select your Occupation"), MaxLength(50)]
        public string Job_title { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter your date of Birth"), MaxLength(50)]
        public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Please select your Salary Range"), MaxLength(50)]
        public long Income { get; set; }

        [Required(ErrorMessage = "Please select your Country"), MaxLength(50)]
        public string CountryOfBirth { get; set; }

        [Required(ErrorMessage = "Please select your Nationality"), MaxLength(50)]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter your address"), MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Post Code"), MaxLength(8)]
        public string Post_Code { get; set; }

        [ForeignKey ("EmployeeModel")]
        public int Supervisor { get; set; }
        public EmployeeModel? Manager { get; set; }

        public DateTime Date_Joined { get; set; }

        [Required(ErrorMessage = "Please enter your Email address"), MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password"), MaxLength(80)]
        [DataType(DataType.Password)]
        public string Banking_Password { get; set; }

        [Required(ErrorMessage = "Please enter your Confirmation Password"), MaxLength(80)]
        [DataType(DataType.Password)]
        [Compare("Banking_Password", ErrorMessage = "Password do not match"]
        public string Banking_ConfirmationPassword { get; set; }
    }

}

