using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IBankCardRepository
    {
        //Services from the database or calls from the datase

        Task<IEnumerable<BankCardModel>> GetAll();
        Task<BankCardModel> getByIdAsync(int id);


        //Task<IEnumerable<BankCardModel>> getCustomerByBankCard(int CustomerId);

        //Task<IEnumerable<BankCardModel>> GetAccountByBankCard(int AccountNo);

        bool Add(BankCardModel bankCard);

        bool Update(BankCardModel bankCard);

        bool Delete(BankCardModel bankCard);

        bool Save();

     

    }
}
