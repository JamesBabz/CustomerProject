using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;

namespace DAL.Repositories
{
    class CustomerRepository : IRepository<Customer>
    {
        public Customer Create(Customer ent)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Customer Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
