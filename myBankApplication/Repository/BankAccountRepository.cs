using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankAccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(AccountModel account)
        {
            _context.Add(account);
            return Save();
        }

        public bool Delete(AccountModel account)
        {
            _context.Remove(account);
            return Save();
        }

        public async Task<IEnumerable<AccountModel>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public Task<AccountModel> getByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<AccountModel>> GetAccountByCustomer_Id(int CustomerId)
        //{
        //    return await _context.Accounts.Where(c => c.AppUserId.Id == CustomerId).ToListAsync();

        //}
        //public async Task<AccountModel> getByIdAsync(int id)
        //{
        //    return await _context.Accounts.FirstOrDefaultAsync(i => i.AccountNo == id);
        //}

        //public async Task<IEnumerable<AccountModel>> GetAccountByBankName(string BankName)
        //{
        //    return await _context.Accounts.Where(x => x.Bank.BankName.Contains(BankName)).ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(AccountModel account)
        {
            _context.Update(account);
            return Save();
        }
    }
}
