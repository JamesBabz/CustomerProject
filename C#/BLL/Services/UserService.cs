using BLL.BusinessObjects;
using BLL.Converters;
using BLL.IServices;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IDALFacade facade;
        private UserConverter userConv = new UserConverter();
        private User newUser;

        public UserService(IDALFacade facade)
        {
            this.facade = facade;
        }

        public UserBO Create(UserBO user)
        {
            string password;
            byte[] passwordHash, passwordSalt;
            using (var uow = facade.UnitOfWork)
            {
                password = user.UserPassword;
                newUser = uow.UserRepository.Create(userConv.Convert(user));
                PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                newUser.PasswordHash = passwordHash;
                newUser.PasswordSalt = passwordSalt;

                uow.Complete();
                return userConv.Convert(newUser);
            }
        }

        public UserBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newUser = uow.UserRepository.Delete(id);
                uow.Complete();
                return userConv.Convert(newUser);
            }
        }

        public UserBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                newUser = uow.UserRepository.Get(id);
                uow.Complete();
                return userConv.Convert(newUser);
            }
        }

        public List<UserBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.UserRepository.GetAll().Select(userConv.Convert).ToList();
            }
        }

        public UserBO Update(UserBO user)
        {
            using (var uow = facade.UnitOfWork)
            {
                var userFromDb = uow.UserRepository.Get(user.Id);
                if (userFromDb == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                userFromDb.Id = user.Id;
                userFromDb.Username = user.Username;
                userFromDb.PasswordHash = user.PasswordHash;
                userFromDb.PasswordSalt = user.PasswordSalt;
                userFromDb.IsAdmin = user.IsAdmin;
                uow.Complete();

                return userConv.Convert(userFromDb);
            }
        }
    }
}
