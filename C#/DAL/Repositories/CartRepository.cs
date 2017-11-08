using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class CartRepository : IRepository<Cart>
    {
        CustomerProjectContext _context;

        public CartRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public Cart Create(Cart ent)
        {
            _context.Cart.Add(ent);
            return ent;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _context.Cart.Include(c => c.Customer).ToList();
        }

        public IEnumerable<Cart> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Cart Get(int Id)
        {
            return _context.Cart.FirstOrDefault(x => x.Id == Id);
        }

        public Cart Delete(int Id)
        {
            var cart = Get(Id);
            _context.Cart.Remove(cart);
            return cart;
        }
    }
}
