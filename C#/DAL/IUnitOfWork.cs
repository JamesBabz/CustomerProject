using System;
using DAL.Entities;
using DAL.Repositories;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Cart> CartRepository { get; }
        IRepository<CartItem> CartItemRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<User> UserRepository { get; }

        int Complete();
    }
}
