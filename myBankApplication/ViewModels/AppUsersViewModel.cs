﻿using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class AppUsersViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }


        public string FName { get; set; }

        public string FullName
        {
            get { return FName+" " +MName+" " + LName; }
        }

        public string? MName { get; set; }



        public string LName { get; set; }



        public Gender Gender { get; set; }


        public long Income { get; set; }


        public string CountryOfBirth { get; set; }


        public string Nationality { get; set; }


        public string Post_Code { get; set; }

        public string Email { get; set;  }

        public string bankcardNumber { get; set; }

        public int? totalTransactions { get { return Transactions.Count(); } }




        //[Required(ErrorMessage = "Please Upload profile picture")]
        public string? Profile_Picture { get; set; }
        //[Required(ErrorMessage = "Please upload proof of Id")]
        public string? Proof_Id { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Joined { get; set; } = DateTime.Now;


        public ICollection<AccountModel> Accounts { get; set; }

        public ICollection<BankCardModel> BankCards { get; set; }

        public ICollection<DepositChequeModel> DepositCheque { get; set; }

        public ICollection<TransactionModel> Transactions { get; set; }
    }
}
