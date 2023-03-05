using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public bool Add(CustomerModel customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Delete(CustomerModel customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<CustomerModel> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(i => i.Email.Contains(email));
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(i => i.Customer_Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CustomerModel customer)
        {
            _context.Update(customer);
            return Save();
        }
    }
}
