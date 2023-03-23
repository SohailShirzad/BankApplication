﻿using Azure;
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


        Task<TransactionModel> GetTransactionByDate(DateTime date);

        bool Add(TransactionModel transaction);
        bool Update(TransactionModel transaction);
        bool Delete(TransactionModel transaction);
        bool Save();
    }
}
