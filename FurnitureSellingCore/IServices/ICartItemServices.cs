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
        public Task<CartItemDTO> GetByIdCartItem(int Id);
        public Task<List<CartItemDTO>> GetAllCartItem();
        public Task CreateCartItem(CreateCartItemDTO dto);
        public Task UpdateCartItem(CartItemDTO dto);
        public Task DeleteCartItem(int Id);
    }
}
