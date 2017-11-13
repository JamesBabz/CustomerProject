using DAL.Context;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class CartItemRepository : IRepository<CartItem>
    {
        CustomerProjectContext _context;

        public CartItemRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public CartItem Create(CartItem ent)
        {
            _context.CartItems.Add(ent);
            return ent;
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _context.CartItems.ToList();
        }

        public IEnumerable<CartItem> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public CartItem Get(int Id)
        {
            return _context.CartItems.FirstOrDefault(x => x.Id == Id);
        }

        public CartItem Delete(int Id)
        {
            var cartItem = Get(Id);
            _context.CartItems.Remove(cartItem);
            return cartItem;
        }
    }
}
