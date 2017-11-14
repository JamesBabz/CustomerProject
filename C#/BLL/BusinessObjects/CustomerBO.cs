using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class CustomerBO : IBusinessObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public UserBO UserBo { get; set; }
    }
}
