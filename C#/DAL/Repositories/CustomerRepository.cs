using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;

namespace DAL.Repositories
{
    class CustomerRepository : IRepository<Customer>
    {
        CustomerProjectContext _context;

        CustomerRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public Customer Create(Customer ent)
        {
            _context.Customers.Add(ent);
            return ent;
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
        }

        public Customer Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
