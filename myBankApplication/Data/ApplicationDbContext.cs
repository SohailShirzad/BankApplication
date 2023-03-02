using Microsoft.EntityFrameworkCore;
using myBankApplication.Models;

namespace myBankApplication.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Staff { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BankModel> Bank { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
