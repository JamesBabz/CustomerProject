using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class ProductRepository : IRepository<Product>
    {
        CustomerProjectContext _context;

        public ProductRepository(CustomerProjectContext context)
        {
            _context = context;
        }

        public Product Create(Product ent)
        {
            _context.Products.Add(ent);
            return ent;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetAllById(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Product Get(int Id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == Id);
        }

        public Product Delete(int Id)
        {
            var product = Get(Id);
            _context.Products.Remove(product);
            return product;
        }
    }
}
