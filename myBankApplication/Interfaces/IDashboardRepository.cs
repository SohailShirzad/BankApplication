using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IDashboardRepository
    {

        Task<List<AccountModel>> GetAllUserAccounts();

        Task<List<TransactionModel>> GetAllUsersTransactions();

        //More services
    }
}
