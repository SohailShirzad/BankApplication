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
        public async Task<List<AccountModel>> GetAllUserAccounts()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userAccounts = _context.Accounts.Where(r => r.AppUserId == curUser);

            return userAccounts.ToList();
        }

        public async Task<List<TransactionModel>> GetAllUsersTransactions()
        {
          throw new NotImplementedException();  
        }
    }
}
