using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IDepositChequeRepository
    {
        Task<IEnumerable<DepositChequeModel>> GetAll();

        Task<DepositChequeModel> GetByIdAsync(int id);

        Task <IEnumerable<DepositChequeModel>> GetChequeDepositByUserAccount(int accountNumber);

        Task<DepositChequeModel> GetChequeDepositByReference(string reference);

        bool Add(DepositChequeModel depositChequeModel);
        bool Update(DepositChequeModel depositChequeModel);
        bool Delete(DepositChequeModel depositChequeModel);
        bool Save();
    }
}
