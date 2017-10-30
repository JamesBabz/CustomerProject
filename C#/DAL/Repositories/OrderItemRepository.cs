using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;

namespace DAL.Repositories
{
    class OrderItemRepository : IRepository<OrderItem>
    {
        CustomerProjectContext _context;

        public OrderItemRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public OrderItem Create(OrderItem ent)
        {
            _context.OrderItems.Add(ent);
            return ent;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItems.ToList();
        }

        public IEnumerable<OrderItem> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public OrderItem Get(int Id)
        {
            return _context.OrderItems.FirstOrDefault(x => x.Id == Id);
        }

        public OrderItem Delete(int Id)
        {
            var orderItem = Get(Id);
            _context.OrderItems.Remove(orderItem);
            return orderItem;
        }
    }
}
