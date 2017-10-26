using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.BusinessObjects;
using BLL.Converters;
using BLL.IServices;
using DAL;
using DAL.Entities;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private IDALFacade facade;
        private ProductConverter prodConv = new ProductConverter();
        private Product newProduct;


        public ProductService(IDALFacade facade)
        {
            this.facade = facade;
        }


        public ProductBO Create(ProductBO product)
        {
            using (var uow = facade.UnitOfWork)
            {
                newProduct = uow.ProductRepository.Create(prodConv.Convert(product));
                uow.Complete();
                return prodConv.Convert(newProduct);
            }
        }

        public ProductBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newProduct = uow.ProductRepository.Delete(id);
                uow.Complete();
                return prodConv.Convert(newProduct);
            }
        }

        public ProductBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newProduct = uow.ProductRepository.Get(id);
                uow.Complete();
                return prodConv.Convert(newProduct);
            }
        }

        public List<ProductBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.ProductRepository.GetAll().Select(prodConv.Convert).ToList();
            }
        }

        public ProductBO Update(ProductBO product)
        {
            using (var uow = facade.UnitOfWork)
            {
                var productFromDb = uow.ProductRepository.Get(product.Id);
                if (productFromDb == null)
                {
                    throw new InvalidOperationException("Product not found");
                }

                productFromDb.Id = product.Id;
                productFromDb.Name = product.Name;
                productFromDb.ListPrice = product.ListPrice;
                uow.Complete();

                return prodConv.Convert(productFromDb);

            }
        }
    }
}
