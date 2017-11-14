using System;
using System.Collections.Generic;
using System.Text;
using DAL.Context;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        CustomerProjectContext _context;

        public UserRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public User Create(User ent)
        {
            _context.Users.Add(ent);
            return ent;
        }

        public User Delete(int Id)
        {
            var user = Get(Id);
            _context.Users.Remove(user);
            return user;
        }

        public User Get(int Id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
