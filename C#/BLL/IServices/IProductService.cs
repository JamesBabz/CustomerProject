using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.IServices
{
    public interface IProductService
    {
        //C
        ProductBO Create(ProductBO product);
        List<ProductBO> AddProducts(List<ProductBO> products);
        //R
        List<ProductBO> GetAll();
        //U
        ProductBO Update(ProductBO product);
        //D
        ProductBO Delete(int id);

    }
}
