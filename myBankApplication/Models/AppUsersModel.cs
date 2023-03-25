﻿using Microsoft.AspNetCore.Identity;
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
        public string FName { get; set; }

        [MaxLength(50)]
        
        public string? MName { get; set; }

        
        [Required(ErrorMessage = "Please enter your Last name"), MaxLength(50)]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please select your education"), MaxLength(200)]
        public string Education { get; set; }

        [Required(ErrorMessage = "Please select your Occupation"), MaxLength(200)]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Please select your Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter your date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select your Salary Range")]
        public long Income { get; set; }

        [Required(ErrorMessage = "Please select your Country"), MaxLength(50)]
        public string CountryOfBirth { get; set; }

        [Required(ErrorMessage = "Please select your Nationality"), MaxLength(50)]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter your address"), MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Post Code"), MaxLength(8)]
        public string Post_Code { get; set; }



        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Joined { get; set; } = DateTime.Now;
        //[Required(ErrorMessage = "Please Upload profile picture")]
        public string? Profile_Picture { get; set; }
        //[Required(ErrorMessage = "Please upload proof of Id")]
        public string? Proof_Id { get; set; }

        public ICollection<AccountModel> Accounts { get; set; }
        
        public ICollection<BankCardModel> BankCards { get; set; }

        public ICollection <StatementModel> Statements { get; set; }  

        public ICollection <TransactionModel> Transactions { get; set; }   
    }
}