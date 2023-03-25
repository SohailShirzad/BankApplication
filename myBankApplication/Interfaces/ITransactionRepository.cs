using Azure;
using Microsoft.AspNetCore.Mvc;
using myBankApplication.Models;
using System.Transactions;

namespace myBankApplication.Interfaces
{
    public interface ITransactionRepository
    {

        Task<IEnumerable<TransactionModel>> GetAll();
        Task<TransactionModel> GetByIdAsync(int id);

        Task <IEnumerable<TransactionModel>> GetTransactionByAccountNo (int accountNo);

        Task<TransactionModel> GetTransactionByReference (string reference);




 


    }
}
