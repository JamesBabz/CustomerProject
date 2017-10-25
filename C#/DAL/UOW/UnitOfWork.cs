using System;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Customer> CustomerRepository { get; internal set; }



        public CustomerProjectContext context;
        private static DbContextOptions<CustomerProjectContext> optionsStatic;

        public UnitOfWork(DbOptions opt)
        {
             if(opt.Environment == "Development" && String.IsNullOrEmpty(opt.ConnectionString)){
                optionsStatic = new DbContextOptionsBuilder<CustomerProjectContext>()
                   .UseInMemoryDatabase("TheDB")
                   .Options;
                context = new CustomerProjectContext(optionsStatic);
            }
            else{
                var options = new DbContextOptionsBuilder<CustomerProjectContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
                context = new CustomerProjectContext(options);
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
