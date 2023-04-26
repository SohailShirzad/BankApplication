using Microsoft.AspNetCore.Mvc;
using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IAccountRepository
    {
        //Services from the database or calls from the datase

        Task<IEnumerable<AccountModel>> GetAll();

        Task<AccountModel> getByIdAsync(int id);




        //Task<IEnumerable<AccountModel>> GetAccountByCustomer_Id(int CustomerId);

        //Task<IEnumerable<AccountModel>> GetAccountByBankName(string BankName);


        bool Add (AccountModel account);

        bool Update (AccountModel account);

        bool Delete (AccountModel account);

        bool Save();




    }
}
