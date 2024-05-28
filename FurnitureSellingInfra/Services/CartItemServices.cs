using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class CartItemServices : ICartItemServices
    {
        public Task CreateCartItem(CartItemDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCartItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CartItemDTO> GetAllCartItem()
        {
            throw new NotImplementedException();
        }

        public Task<CartItemDTO> GetByIdCartItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartItem(CartItemDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
