using BLL.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using BLL.BusinessObjects;
using DAL;
using BLL.Converters;
using DAL.Entities;
using System.Linq;

namespace BLL.Services
{
    public class CartItemService : ICartItemService
    {

        private IDALFacade facade;
        private CartItemConverter cartItemConv = new CartItemConverter();
        private CartConverter cartConv = new CartConverter();
        private ProductConverter prodConv = new ProductConverter();
        private CartItem _newCartItem;

        public CartItemService(IDALFacade facade)
        {
            this.facade = facade;
        }

        public List<CartItemBO> AddCartItems(List<CartItemBO> cartItems)
        {
            throw new NotImplementedException();
        }

        public CartItemBO Create(CartItemBO cartItem)
        {
            using (var uow = facade.UnitOfWork)
            {
                _newCartItem = uow.CartItemRepository.Create(cartItemConv.Convert(cartItem));
                uow.Complete();
                return cartItemConv.Convert(_newCartItem);
            }
        }

        public CartItemBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                _newCartItem = uow.CartItemRepository.Delete(id);
                uow.Complete();
                return cartItemConv.Convert(_newCartItem);
            }
        }

        public CartItemBO Get(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                _newCartItem = uow.CartItemRepository.Get(id);
                uow.Complete();
                return cartItemConv.Convert(_newCartItem);
            }
        }

        public List<CartItemBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CartItemRepository.GetAll().Select(cartItemConv.Convert).ToList();
            }
        }

        public CartItemBO Update(CartItemBO cartItem)
        {
            using (var uow = facade.UnitOfWork)
            {
                var cartItemFromDb = uow.CartItemRepository.Get(cartItem.Id);
                if (cartItemFromDb == null)
                {
                    throw new InvalidOperationException("Cart not found");
                }

                cartItemFromDb.Id = cartItem.Id;
                cartItemFromDb.Cart = cartConv.Convert(cartItem.Cart);
                cartItemFromDb.CartId = cartItem.CartId;
                cartItemFromDb.Product = prodConv.Convert(cartItem.Product);
                cartItemFromDb.ProductId = cartItem.ProductId;

                uow.Complete();

                return cartItemConv.Convert(cartItemFromDb);

            }
        }
        
    }
}
