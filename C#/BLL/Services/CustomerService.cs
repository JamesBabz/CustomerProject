﻿using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using BLL.IServices;
using DAL.Entities;
using DAL.Facade;
using DAL.Repositories;

namespace BLL.Services
{ 

    public class CustomerService : ICustomerService
    {
        private DALFacade facade;
        private CustomerConverter custConv = new CustomerConverter();
        private Customer newCustomer;



        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }

        public CustomerBO Create(CustomerBO cust)
        {
            using (var uow = facade.UnitOfWork)
            {
                newCustomer = uow.
            }
        }

        public CustomerBO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerBO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerBO Update(CustomerBO cust)
        {
            throw new NotImplementedException();
        }
    }
}
