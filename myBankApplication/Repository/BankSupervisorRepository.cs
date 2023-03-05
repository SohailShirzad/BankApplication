using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankSupervisorRepository : ISupervisorRepository
    {
        private readonly ApplicationDbContext _context;

        public BankSupervisorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CustomerModel customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Add(TransactionModel transaction)
        {
            _context.Add(transaction);
            return SaveTransaction();
        }

        public bool Add(EmployeeModel employee)
        {
            _context.Add(employee);
            return SaveEmployee();
        }

        public bool Add(BankCardModel bankCard)
        {
            _context.Add(bankCard);
            return SaveBankCard();
        }

        public bool Add(BankModel bankModel)
        {
            _context.Add(bankModel);
            return SaveBank();
        }

        public bool Delete(CustomerModel customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public bool Delete(TransactionModel transaction)
        {
            _context.Remove(transaction);
            return SaveTransaction();
        }

        public bool Delete(EmployeeModel employee)
        {
            _context.Remove(employee);
            return SaveEmployee();
        }

        public bool Delete(BankCardModel bankCard)
        {
            _context.Remove(bankCard);
            return SaveBankCard();
        }

        public bool Delete(BankModel bankModel)
        {
            _context.Remove(bankModel);
            return SaveBank();
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public Task<IEnumerable<BankCardModel>> GetBankByAccountNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BankCardModel>> GetBankCardbyCustomerIdAsync(int Customer_Id)
        {
            return await _context.BankCards.Where(x => x.Customer.Customer_Id == Customer_Id).ToListAsync();
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(i => i.Customer_Id == id);
        }

        public async Task<IEnumerable<AccountModel>> GetCustomerByAccountNumber(int Customer_Id)
        {
            return await _context.Accounts.Where(x => x.Customer.Customer_Id == Customer_Id).ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            return await _context.Staff.FirstOrDefaultAsync(i => i.Employee_Id == id);
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<TransactionModel> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<IEnumerable<TransactionModel>> GetTransactionsByAccountNumberAsync(int AccountNumber)
        {
            return await _context.Transactions.Where(x => x.Account.AccountNo == AccountNumber).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SaveBank()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SaveBankCard()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SaveEmployee()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SaveTransaction()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CustomerModel customer)
        {
            _context.Update(customer);
            return Save();
        }

        public bool Update(TransactionModel transaction)
        {
            _context.Update(transaction);
            return SaveTransaction();
        }

        public bool Update(EmployeeModel employee)
        {
            _context.Update(employee);
            return SaveEmployee();
        }

        public bool Update(BankCardModel bankCard)
        {
            _context.Update(bankCard);
            return SaveBankCard();
        }

        public bool Update(BankModel bankModel)
        {
            _context.Update(bankModel);
            return SaveBank();
        }
        public bool Add(StatementModel statement)
        {
            _context.Add(statement);
            return SaveStatement();
        }

        public bool Delete(StatementModel statement)
        {
            _context.Remove(statement);
            return SaveStatement();
        }

        public bool SaveStatement()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        bool ISupervisorRepository.Update(StatementModel statement)
        {
            _context.Update(statement);
            return SaveStatement();
        }
    }
}
