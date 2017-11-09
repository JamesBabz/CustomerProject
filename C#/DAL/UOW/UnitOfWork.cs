using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; internal set; }
        public IRepository<Order> OrderRepository { get; internal set; }
        public IRepository<Cart> CartRepository { get; internal set; }
        public IRepository<Product> ProductRepository { get; internal set; }
        public IRepository<User> UserRepository { get; internal set; }


        public CustomerProjectContext context;
        private static DbContextOptions<CustomerProjectContext> optionsStatic;

        public UnitOfWork(DbOptions opt)
        {
            context = new CustomerProjectContext();

            CustomerRepository = new CustomerRepository(context);
            OrderRepository = new OrderRepository(context);
            CartRepository = new CartRepository(context);
            ProductRepository = new ProductRepository(context);
            UserRepository = new UserRepository(context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();


        }

    }
}
