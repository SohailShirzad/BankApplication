using myBankApplication.Data.Enum;
using myBankApplication.Models;

namespace myBankApplication.ViewModels
{
    public class CreateTransactionViewModel
    {
        public int Id { get; set; }

        public AccountModel Account { get; set; }

        public string BeniciaryName { get; set; }

        public TransactionType TransactionType { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public String Reference { get; set; }
    }
}

