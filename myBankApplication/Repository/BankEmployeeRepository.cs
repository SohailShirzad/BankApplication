using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public bool Add(EmployeeModel employee)
        {
            _context.Add(employee);
            return Save();
        }

        public bool Delete(EmployeeModel employee)
        {
            _context.Remove(employee);
            return Save();
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<EmployeeModel> getByIdAsync(int id)
        {
            return await _context.Staff.FirstOrDefaultAsync(i => i.Employee_Id == id);
        }

        //public async Task<IEnumerable<EmployeeModel>> GetEmployeeManager(int employeeId)
        //{
            //return await _context.Staff.FirstOrDefaultAsync(i => i.Supervisor == employeeId);
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(EmployeeModel employee)
        {
            _context.Update(employee);
            return Save();

        }
    }
}
