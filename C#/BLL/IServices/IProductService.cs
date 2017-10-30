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
        //R
        List<ProductBO> GetAll();
        ProductBO Get(int id);
        //U
        ProductBO Update(ProductBO product);
        //D
        ProductBO Delete(int id);

    }
}
