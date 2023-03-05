using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankStatementRepository : IStatementRepository
    {
        private readonly ApplicationDbContext _context;

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

        public async Task<IEnumerable<StatementModel>> GetStatements()
        {
            return await _context.Statements.ToListAsync();
        }

        public async Task<StatementModel> GetStatementsByIdAsync(int id)
        {
            return await _context.Statements.FirstOrDefaultAsync(i => i.StatementID == id);
        }

        public bool SaveStatement()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(StatementModel statement)
        {
            _context.Update(statement);
            return SaveStatement();
        }
    }
}
