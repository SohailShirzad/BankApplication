using Microsoft.EntityFrameworkCore;
using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IAppUsersRepository
    {

        Task<IEnumerable<AppUsersModel>> GetAll();

        Task<AppUsersModel> GetUserById(string id);

        Task<AppUsersModel> GetByEmailAsync(string email);

        // Accounts
        Task <ICollection<AccountModel>> GetAllUsersAccounts();

        // Transactions
        Task<ICollection<TransactionModel>> GetAllUsersTransactions();



        Task<ICollection<DepositChequeModel>> GetAllUsersCheques();


        //Bank Cards

        // Accounts
        Task<ICollection<BankCardModel>> GetAllUsersBankCards();

        bool Add(AppUsersModel customer);
        bool Update(AppUsersModel customer);
        bool Delete(AppUsersModel customer);
        bool Save();
    }
}
