using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface ISupervisorRepository
    {
        Task<IEnumerable<CustomerModel>> GetAll();
        Task<CustomerModel> GetByIdAsync(int id);

        Task<IEnumerable<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);


        Task<IEnumerable<TransactionModel>> GetTransactions();
        Task<TransactionModel> GetTransactionByIdAsync(int id);

        Task<IEnumerable<BankCardModel>> GetBankByAccountNumber(int accountNumber);

        Task<IEnumerable<BankCardModel>> GetBankCardbyCustomerIdAsync(int Customer_Id);


        Task<IEnumerable<AccountModel>> GetCustomerByAccountNumber(int Customer_Id);

        Task<IEnumerable<TransactionModel>> GetTransactionsByAccountNumberAsync(int AccountNumber);


        bool Add (CustomerModel customer);
        bool Update (CustomerModel customer);
        bool Delete (CustomerModel customer);
        bool Save();

        bool Add (TransactionModel transaction);
        bool Update (TransactionModel transaction);
        bool Delete (TransactionModel transaction);
        bool SaveTransaction();


        bool Add (EmployeeModel employee);
        bool Update (EmployeeModel employee);
        bool Delete (EmployeeModel employee);
        bool SaveEmployee();


        bool Add (BankCardModel bankCard);
        bool Update (BankCardModel bankCard);
        bool Delete (BankCardModel bankCard);
        bool SaveBankCard();


        bool Add(BankModel bankModel);
        bool Update(BankModel bankModel);
        bool Delete(BankModel bankModel);
        bool SaveBank();

        bool Add (StatementModel statement);
        bool Update(StatementModel statement);
        bool Delete(StatementModel statement);
        bool SaveStatement();


        

        
    }
}
