using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IEmployeeRepository
    {

        //Services from the database or calls from the datase

        Task<IEnumerable<EmployeeModel>> GetAll();
        Task<EmployeeModel> getByIdAsync(int id);


        //Task<IEnumerable<EmployeeModel>> GetEmployeeManager(int employeeId);

        bool Add (EmployeeModel employee);

        bool Update (EmployeeModel employee);

        bool Delete (EmployeeModel employee);

        bool Save();

 
    }
}
