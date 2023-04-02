using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankCardsRepository : IBankCardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankCardsRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Add(BankCardModel bankCard)
        {
            _context.Add(bankCard);
            return Save();
           
        }

        public bool Delete(BankCardModel bankCard)
        {
            _context.Remove(bankCard);
            return Save();
        }

        public async Task<IEnumerable<BankCardModel>> GetAccountByBankCard(int AccountNo)
        {
            return await _context.BankCards.Where(x => x.AccountNumber.AccountNo == AccountNo).ToListAsync();
        }

        public async Task<IEnumerable<BankCardModel>> GetAll()
        {
            return await _context.BankCards.ToListAsync();
        }


        public async Task<BankCardModel> GetByIdAsync(int id)
        {
            return await _context.BankCards.FirstOrDefaultAsync(i => i.CardNumber.Equals(id));
        }




        //public async Task<IEnumerable<BankCardModel>> getCustomerByBankCard(int CustomerId)
        //{
        //    return await _context.BankCards.Where(x => x.Customer.Customer_Id == CustomerId).ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(BankCardModel bankCard)
        {
            _context.Update(bankCard);
            return Save();
        }
    }
}
