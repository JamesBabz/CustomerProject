using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Product : IEntity
    {
        public int Id { get; internal set; }

        public string Name { get; set; }

        public double ListPrice { get; set; }

    }
}
