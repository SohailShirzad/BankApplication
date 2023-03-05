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
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<BankModel> Bank { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<BankCardModel> BankCards { get; set; }
        public DbSet<StatementModel> Statements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankCardModel>().HasKey(bc => new { bc.cardNumber, bc.CVVNumber });
        }

    }

    // override the on ModelCreating method. 

   
}
