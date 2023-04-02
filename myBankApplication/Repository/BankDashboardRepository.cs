using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankDashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BankDashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //Accounts
        public async Task<List<AccountModel>> GetAllUserAccounts()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userAccounts = _context.Accounts.Where(r => r.AppUserId == curUser);

            return userAccounts.ToList();
        }

        
        //Trransactions 

        public async Task<List<TransactionModel>> GetAllUsersTransactions()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userTransactions = _context.Transactions.Where(r => r.AppUserId == curUser);
            return userTransactions.ToList();
        }

        public Task<List<BankCardModel>> GetAllUsersBankCards()
        {
            //var userBankCards = _applicationDbContext.BankCards.Include("AppUsers").ToList();
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBankCards = _context.BankCards.Include("AppUsers").Where(r => r.AppUserId == curUser);
            return userBankCards.ToListAsync();
        }

    }
}
