﻿using System;
using DAL.Entities;
using DAL.Repositories;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Cart> CartRepository { get; }
        IRepository<Product> ProductRepository { get; }

        int Complete();
    }
}
