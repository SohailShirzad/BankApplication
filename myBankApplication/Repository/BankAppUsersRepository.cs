﻿using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Repository
{
    public class BankAppUsersRepository : IAppUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public BankAppUsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }   

        public bool Add(AppUsersModel customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Delete(AppUsersModel customer)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<AppUsersModel>> GetAll()
        {
            return await _context.Users.ToListAsync();
            
        }

        public async Task<AppUsersModel> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Email.Contains(email));
        }

        public async Task<AppUsersModel> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(AppUsersModel customer)
        {
            _context.Update(customer);
            return Save();
        }

   
    }
}