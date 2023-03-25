using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IAppUsersRepository
    {

        Task<IEnumerable<AppUsersModel>> GetAll();

        Task<AppUsersModel> GetUserById(string id);

        Task<AppUsersModel> GetByEmailAsync(string email);

        bool Add(AppUsersModel customer);
        bool Update(AppUsersModel customer);
        bool Delete(AppUsersModel customer);
        bool Save();
    }
}
