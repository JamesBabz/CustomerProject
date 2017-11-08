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

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Id = 1,
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Id = 2,
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };


            context.Users.AddRange(users);


        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }





        //if (opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString))
        //{
        //    optionsStatic = new DbContextOptionsBuilder<CustomerProjectContext>()
        //        .UseInMemoryDatabase("TheDB")
        //        .Options;
        //    context = new CustomerProjectContext(optionsStatic);
        //    context.Database.EnsureCreated();
        //}
        //else

        //    var options = new DbContextOptionsBuilder<CustomerProjectContext>()
        //        .UseSqlServer(opt.ConnectionString)
        //        .Options;



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
