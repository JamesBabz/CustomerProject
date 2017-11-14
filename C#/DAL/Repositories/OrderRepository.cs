using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;

namespace DAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        CustomerProjectContext _context;

        public OrderRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public Order Create(Order ent)
        {
            _context.Orders.Add(ent);
            return ent;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Order Get(int Id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public Order Delete(int Id)
        {
            var order = Get(Id);
            _context.Orders.Remove(order);
            return order;
        }
    }
}
