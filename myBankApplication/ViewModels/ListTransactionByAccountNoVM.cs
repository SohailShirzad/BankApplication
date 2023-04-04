using myBankApplication.Models;

namespace myBankApplication.ViewModels
{
    public class ListTransactionByAccountNoVM
    {
        public IEnumerable<TransactionModel> Transactions { get; set; }

        public bool NoTransactionWarning { get; set; }

        public int AccountNo { get; set; }
    }
}
