using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface ICustomerRepository
    {

        Task<IEnumerable<CustomerModel>> GetAll();

        Task<CustomerModel> GetByIdAsync(int id);

        Task<CustomerModel> GetByEmailAsync(string email);

        

     



        bool Add(CustomerModel customer);
        bool Update(CustomerModel customer);
        bool Delete(CustomerModel customer);
        bool Save();
    }
}
