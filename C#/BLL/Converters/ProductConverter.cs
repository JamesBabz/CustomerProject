using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class ProductConverter
    {
        public Product Convert(ProductBO product)
        {
            if (product == null) { return null; }
            {
                return new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    ListPrice = product.ListPrice
                };
            }
        }

        public ProductBO Convert(Product product)
        {
            if (product == null) { return null; }
            {
                return new ProductBO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    ListPrice = product.ListPrice
                };
            };
        }


    }
}
