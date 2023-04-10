using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankAppUsersRepository : IAppUsersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankAppUsersRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }   

        public bool Add(AppUsersModel customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Delete(AppUsersModel customer)
        {
            _context.Remove(customer);
            return Save();
        }
        
        public async Task<IEnumerable<AppUsersModel>> GetAll()
        {
            return await _context.Users.ToListAsync();
            
        }




        //Accounts

        public async Task<ICollection<AccountModel>> GetAllUsersAccounts()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userAccounts = _context.Accounts.Where(r => r.AppUserId == curUser);

            return userAccounts.ToList();
        }


        // Bank Cards

        public async Task<ICollection<BankCardModel>> GetAllUsersBankCards()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBankCards = _context.BankCards.Include("AppUsers").Where(r => r.AppUserId == curUser);
            return userBankCards.ToList();
        }


        // Cheques

        public async  Task<ICollection<DepositChequeModel>> GetAllUsersCheques()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userCheques = _context.DepositCheque.Where(r => r.AppUserId == curUser);
            return userCheques.ToList();
        }


        // Transactins

        public async Task<ICollection<TransactionModel>> GetAllUsersTransactions()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();

            var acc = await _context.Accounts.ToListAsync();
            var accountFrom = acc.Where(a => a.AppUserId == curUser).SingleOrDefault();

            var userTransactions = _context.Transactions.Where(t => t.DestAccount == accountFrom.AccountNo || t.AccountNo == accountFrom.AccountNo);
            return userTransactions.ToList();
        }




        public async Task<AppUsersModel> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Email.Contains(email));
        }

        public async Task<AppUsersModel> GetUserById(string id)
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            return await _context.Users.FindAsync(curUser);
        }

        public async Task<AppUsersModel> GetUserByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(AppUsersModel customer)
        {
            _context.Update(customer);
            return Save();
        }

   
    }
}
