using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface IUserService
    {
        //C
        UserBO Create(UserBO product);
        //R
        //List<UserBO> GetAll();
        UserBO Get(int id);
        //U
        UserBO Update(UserBO product);
        //D
        UserBO Delete(int id);
    }
}
