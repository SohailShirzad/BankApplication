using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class IndexTransactionsViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(NullDisplayText = "No recipient")]
        public string? RecipientName { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


        public string? Reference { get; set; }

        public int? AccountNo { get; set; }


        public int? DestAccount { get; set; }

        public string? AppUserId { get; set; }
    }
}
