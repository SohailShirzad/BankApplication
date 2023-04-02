using myBankApplication.Models;

namespace myBankApplication.ViewModels
{
    public class DashboardViewModel
    {
        public List<AccountModel> Accounts { get; set; }

        public List<TransactionModel> Transactions { get; set; }  

        public List<AppUsersModel> AppUsers { get; set; }

        public List<BankCardModel> BankCards { get; set; }
    }
}
