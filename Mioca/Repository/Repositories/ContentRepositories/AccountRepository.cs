using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.ContentRepositories
{
    public interface IAccountRepository
    {
        User GetUserByid(string userId);
    }
    public class AccountRepository:IAccountRepository
    {
        private readonly MiocaDbContext _context;

        public AccountRepository(MiocaDbContext context)
        {
            _context = context;
        }

        public User GetUserByid(string userId)
        {
            return _context.Users.Find(userId);
        }
    }
}
