using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using myBankApplication.Models;

namespace myBankApplication.Data
{
    public class ApplicationDbContext :IdentityDbContext<AppUsersModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<AppUsersModel> AppUsers { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<BankModel> Bank { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<BankCardModel> BankCards { get; set; }
        public DbSet<StatementModel> Statements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BankCardModel>().HasKey(bc => new { bc.CardNumber, bc.CVVNumber });

            modelBuilder.Entity<AccountModel>()
                .Property(s => s.Sort_Code)
                .HasDefaultValue (070493);


           


        }

    }

    // override the on ModelCreating method. 

   
}
