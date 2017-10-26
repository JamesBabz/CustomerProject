using System;
using DAL.Entities;
using DAL.Repositories;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> CustomerRepository { get; }
        //IRepository<Order> OrderRepository { get; }
        //IRepository<OrderItem> OrderitemRepository { get; }
        //IRepository<Product> ProductRepository { get; }

        int Complete();
    }
}
