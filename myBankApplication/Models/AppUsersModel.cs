using Microsoft.AspNetCore.Identity;
using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace myBankApplication.Models
{
    public class AppUsersModel : IdentityUser
    {

        [Required(ErrorMessage = "Please select a title"), MaxLength(20)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter your first name"), MaxLength(50)]
        [RegularExpression(@"^[0-9A-Za-z] +$", ErrorMessage = "Name cannot contain number or special characters")]
        public string FName { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^[0-9A-Za-z] +$", ErrorMessage = "Name cannot contain number or special characters")]
        public string MName { get; set; }

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

        //[Required(ErrorMessage = "Please enter your Password"), MaxLength(80)]
        //[DataType(DataType.Password)]
        //public string Banking_Password { get; set; }

        //[Required(ErrorMessage = "Please enter your Confirmation Password"), MaxLength(80)]
        //[DataType(DataType.Password)]
        //[Compare("Banking_Password", ErrorMessage = "Password do not match"]
        //public string Banking_ConfirmationPassword { get; set; }

        [Required(ErrorMessage = "Please Upload profile picture")]
        public byte[] Profile_Picture { get; set; }
        [Required(ErrorMessage = "Please upload proof of Id")]
        public byte[] Proof_Id { get; set; }

        public ICollection<AccountModel> Accounts { get; set; }
        
        public ICollection<BankCardModel> BankCards { get; set; }

        public ICollection <BankModel> Banks { get; set; }

        public ICollection <StatementModel> Statements { get; set; }  

        public ICollection <TransactionModel> Transactions { get; set; }   
    }
}
