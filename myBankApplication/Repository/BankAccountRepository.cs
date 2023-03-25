using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankAccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public BankAccountRepository(ApplicationDbContext context, IHttpContextAccessor httpcontextAccessor)
        {
            _context = context;
            _httpcontextAccessor = httpcontextAccessor; 
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

        public async Task<List<AccountModel>> getAllUserAccounts()
        {
            var curUser = _httpcontextAccessor.HttpContext?.User.GetUserId();
            var userAccounts = _context.Accounts.Where(r => r.AppUsers.Id == curUser);
            return userAccounts.ToList();
        }

        public Task<AccountModel> getByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<AccountModel>> GetAccountByUserId(string accountId)
        {
            var curUser = _httpcontextAccessor.HttpContext?.User.GetUserId();
            return await _context.Accounts.Where(x => x.AppUsers.Id == accountId).ToListAsync();
        }

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
