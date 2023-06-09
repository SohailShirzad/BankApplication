﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<DepositChequeModel> DepositCheque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountModel>()
                .Property(s => s.Sort_Code)
                .HasDefaultValue("07-04-93");









        }

    }

    // override the on ModelCreating method. 

   
}
