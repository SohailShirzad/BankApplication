using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }


        public string FName { get; set; }



        public string? MName { get; set; }



        public string LName { get; set; }

        public string PhoneNumber { get; set;  }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }


        public long Income { get; set; }


        public string CountryOfBirth { get; set; }


        public string Nationality { get; set; }

        public string Occupation { get; set; }

        public string Address { get; set; }


        public string Post_Code { get; set; }

        public string Email { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_Joined { get; set; } = DateTime.Now;


        public ICollection<AccountModel> Accounts { get; set; }

        public ICollection<BankCardModel> BankCards { get; set; }

        public ICollection<StatementModel> Statements { get; set; }

        public ICollection<TransactionModel> Transactions { get; set; }
    }
}
