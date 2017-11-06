using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL.Entities;

namespace BLL.Converters
{
    public class UserConverter
    {
        public User Convert(UserBO user)
        {
            if (user == null) { return null; }
            {
                return new User()
                {
                    Id = user.Id,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                    IsAdmin = user.IsAdmin
                };
            }
        }

        public UserBO Convert(User user)
        {
            if (user == null) { return null; }
            return new UserBO()
            {
                Id = user.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
