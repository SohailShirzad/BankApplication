﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankDepositChequeRepository : IDepositChequeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BankDepositChequeRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }   

        public bool Add(DepositChequeModel depositChequeModel)
        {
            _context.Add(depositChequeModel);
            return Save();
        }

        public bool Delete(DepositChequeModel depositChequeModel)
        {
            _context.Remove(depositChequeModel);
            return Save();
        }

        public async Task<IEnumerable<DepositChequeModel>> GetAll()
        {
            return await _context.DepositCheque.ToListAsync();
        }

        public async Task<DepositChequeModel> GetById(int id)
        {
            return await _context.DepositCheque.FindAsync(id);
        }

        public Task<DepositChequeModel> GetChequeDepositByReference(string reference)
        {
            throw new NotImplementedException();
        }





        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(DepositChequeModel depositChequeModel)
        {
            _context.Update(depositChequeModel);
            return Save();
        }

        public async Task<IEnumerable<DepositChequeModel>> GetChequeDepositByUserAccount(int accountNumber)
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var acc = await _context.Accounts.ToListAsync();
            var account = acc.Where(a => a.AppUserId == curUser).SingleOrDefault();
            var userCheques = _context.DepositCheque.Where(r => r.AccountNum == account.AccountNo);
            return userCheques.ToList();

        }
    }
}
