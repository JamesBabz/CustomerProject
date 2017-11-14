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
    public class CartService : ICartService
    {
        private IDALFacade facade;
        private CartConverter cartConv = new CartConverter();
        private Cart _newCart;

        public CartService(IDALFacade facade)
        {
            this.facade = facade;
        }


        public List<CartBO> AddCarts(List<CartBO> carts)
        {
            throw new NotImplementedException();
        }

        public CartBO Create(CartBO cart)
        {
            using (var uow = facade.UnitOfWork)
            {
                _newCart = uow.CartRepository.Create(cartConv.Convert(cart));
                uow.Complete();
                return cartConv.Convert(_newCart);
            }
        }

        public CartBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                _newCart = uow.CartRepository.Delete(id);
                uow.Complete();
                return cartConv.Convert(_newCart);
            }
        }

        public CartBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                _newCart = uow.CartRepository.Get(id);
                uow.Complete();
                return cartConv.Convert(_newCart);
            }
        }

        public List<CartBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CartRepository.GetAll().Select(cartConv.Convert).ToList();
            }
        }

        public CartBO Update(CartBO cart)
        {
            using (var uow = facade.UnitOfWork)
            {
                var cartFromDb = uow.CartRepository.Get(cart.Id);
                if (cartFromDb == null)
                {
                    throw new InvalidOperationException("Cart not found");
                }

                cartFromDb.Id = cart.Id;
                //cartFromDb.ProductIds = cart.ProductIds;
                uow.Complete();

                return cartConv.Convert(cartFromDb);

            }
        }
    }
}
