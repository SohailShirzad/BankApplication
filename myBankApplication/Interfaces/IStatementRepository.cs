using myBankApplication.Models;

namespace myBankApplication.Interfaces
{
    public interface IStatementRepository
    {
        // Calls from the database to be used on the application 

        Task<IEnumerable<StatementModel>> GetStatements();

        Task<StatementModel> GetStatementsByIdAsync(int id);

        bool Add(StatementModel statement);
        bool Update(StatementModel statement);
        bool Delete(StatementModel statement);
        bool SaveStatement();


    }
}
