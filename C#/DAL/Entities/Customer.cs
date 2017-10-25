using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; internal set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

    }
}
