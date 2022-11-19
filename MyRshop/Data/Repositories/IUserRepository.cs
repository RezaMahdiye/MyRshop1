using MyRshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Data.Repositories
{
   public interface IUserRepository
    {
     
        void AddUser(Users user);
        bool IsExistUserByEmail(string email);
        Users GetUserForLogin(string Email, string Password);
    }
    public class UserRepository : IUserRepository
    {
        private MyRshopContext _context;
        public UserRepository(MyRshopContext context)
        {
            _context = context;
        }
        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string Email, string Password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == Email && u.Password == Password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
