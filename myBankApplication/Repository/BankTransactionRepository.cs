using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using System.Runtime.InteropServices;

namespace myBankApplication.Repository
{
    public class BankTransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public bool Add(TransactionModel transaction)
        {
            _context.Add(transaction);
            return Save();
        }

        public bool Delete(TransactionModel transaction)
        {
            _context.Remove(transaction);
            return Save();
        }

        public async Task<IEnumerable<TransactionModel>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<TransactionModel> GetByIdAsync(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactionByAccountNo(int accountNo)
        {
            return await _context.Transactions.Where(c => c.Account.AccountNo == accountNo).ToListAsync();
        }

        public async Task<TransactionModel> GetTransactionByDate(DateTime date)
        {
            return await _context.Transactions.FirstOrDefaultAsync(i => i.Date == date);
        }

        public async Task<TransactionModel> GetTransactionByReference(string reference)
        {
            return await _context.Transactions.FirstOrDefaultAsync(i => i.Reference.Contains(reference));
        }
        
        public async Task<TransactionModel> GetTransactionBySwiftCode(int swiftCode)
        {
            return await _context.Transactions.FirstOrDefaultAsync(i => i.SWIFTCode == swiftCode);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(TransactionModel transaction)
        {
            _context.Update(transaction);
            return Save();
        }
    }
}
