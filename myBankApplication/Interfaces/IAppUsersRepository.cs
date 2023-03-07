using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IAppUsersRepository
    {

        Task<IEnumerable<AppUsersModel>> GetAll();

        Task<AppUsersModel> GetByIdAsync(int id);

        Task<AppUsersModel> GetByEmailAsync(string email);

        bool Add(AppUsersModel customer);
        bool Update(AppUsersModel customer);
        bool Delete(AppUsersModel customer);
        bool Save();
    }
}
