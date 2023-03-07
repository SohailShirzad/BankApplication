using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IUserAuthenticationRepository
    {
        Task<StatusModel> LoginAsync(AppUsersLoginModel appUsersLoginModel);
        Task<StatusModel> RegistationAsync(AppUsersRegistrationModel appUsersRegistrationModel);
        Task LogoutAsync();
             
    }
}
