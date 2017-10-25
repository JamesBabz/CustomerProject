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

        OrderRepository(CustomerProjectContext context)
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
