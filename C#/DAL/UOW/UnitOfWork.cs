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
        public IRepository<CartItem> CartItemRepository { get; internal set; }
        public IRepository<Product> ProductRepository { get; internal set; }
        public IRepository<User> UserRepository { get; internal set; }


        public CustomerProjectContext context;
        //private static DbContextOptions<CustomerProjectContext> optionsStatic;

        public UnitOfWork(DbOptions opt)
        {
            context = new CustomerProjectContext();

            CustomerRepository = new CustomerRepository(context);
            OrderRepository = new OrderRepository(context);
            CartRepository = new CartRepository(context);
            CartItemRepository = new CartItemRepository(context);
            ProductRepository = new ProductRepository(context);
            UserRepository = new UserRepository(context);
            
            context.Database.EnsureCreated();
        }
            //// Create two users with hashed and salted passwords
            //string password = "1234";
            //byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            //CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            //CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            //List<User> users = new List<User>
            //{
            //    new User {
            //        Id = 1,
            //        Username = "UserJoe",
            //        PasswordHash = passwordHashJoe,
            //        PasswordSalt = passwordSaltJoe,
            //        IsAdmin = false
            //    },
            //    new User {
            //        Id = 2,
            //        Username = "AdminAnn",
            //        PasswordHash = passwordHashAnn,
            //        PasswordSalt = passwordSaltAnn,
            //        IsAdmin = true
            //    }
            //};

            //context.Users.AddRange(users);
            //Complete();
        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.
        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)
        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
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
