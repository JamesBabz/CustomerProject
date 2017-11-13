using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class CustomerConverter
    {
        public Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            {
                return new Customer()
                {
                    Id = cust.Id,
                    FirstName = cust.FirstName,
                    LastName = cust.LastName,
                    Address = cust.Address,
                    //CartId = cust.CartId,
                    //Cart = new CartConverter().Convert(cust.Cart)

                };
            }
        }

        public CustomerBO Convert(Customer cust)
        {
            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Address = cust.Address,
                //CartId = cust.CartId,
                //Cart = new CartConverter().Convert(cust.Cart)
            };
        }




    }
}
