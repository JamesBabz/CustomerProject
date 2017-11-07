using System;
using BLL.BusinessObjects;
using BLL.Services;
using DAL;
using DAL.Facade;
using Microsoft.Extensions.Configuration;

namespace BLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        private IDALFacade facade;

        public BLLFacade(IConfiguration conf) => facade = new DALFacade(new DbOptions()
        {
            ConnectionString = conf.GetConnectionString("DefaultConnection"),
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
        });

        public CustomerService CustomerService
        {
            get { return new CustomerService(facade); }
        }

        public CartService CartService
        {
            get { return new CartService(facade); }
        }

        public OrderService OrderService
        {
            get { return new OrderService(facade); }
        }

        public ProductService ProductService
        {
            get { return new ProductService(facade); }
        }

        public UserService UserService
        {
            get { return new UserService(facade); }



        }
    }
}
