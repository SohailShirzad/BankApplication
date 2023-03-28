using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.ViewModels
{
    public class CreateAccountViewModel
    {

        public int AccountNo { get; set; }

        public string Sort_Code { get; set; }

        public AccountType AccountType { get; set; }


        public double Balance { get; set; }


        public DateTime Date_Opened { get; set; }

        public Status Status { get; set; } = Status.Active;

        public DateTime Close_Date { get; set; }

        public string AppUserId { get; set; }

    }
}
