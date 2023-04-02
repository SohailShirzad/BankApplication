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
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<AppUsersModel>> GetAll()
        {
            return await _context.Users.ToListAsync();
            
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
