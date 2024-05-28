using FurnitureSellingCore.DTO.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface ICartItemServices
    {
        public Task CreateCartItem(CartItemDTO dto);
        public Task UpdateCartItem(CartItemDTO dto);

        public Task<CartItemDTO> GetByIdCartItem(int Id);
        public Task<CartItemDTO> GetAllCartItem();
        public Task DeleteCartItem(int Id);
    }
}
