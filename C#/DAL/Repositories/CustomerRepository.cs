﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        CustomerProjectContext _context;

        public CustomerRepository(CustomerProjectContext context)
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
            return _context.Customers.ToList();
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
            var customer = Get(Id);
            _context.Customers.Remove(customer);
            return customer;
        }
    }
}
