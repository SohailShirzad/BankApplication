using Azure;
using Microsoft.AspNetCore.Mvc;
using myBankApplication.Data;
using myBankApplication.Models;
using System.Transactions;

namespace myBankApplication.Interfaces
{
    public interface ITransactionRepository
    {


        Task<IEnumerable<TransactionModel>> GetAll();
        Task<TransactionModel> GetByIdAsync(int id);

        Task<IEnumerable<TransactionModel>> GetTransactionByAccountNo(int accountNo);

        Task<TransactionModel> GetTransactionByReference(string reference);



        bool Add(TransactionModel transaction);

        bool Update(TransactionModel transaction);

        bool Delete(TransactionModel transaction);

        bool Save();





    }
}
