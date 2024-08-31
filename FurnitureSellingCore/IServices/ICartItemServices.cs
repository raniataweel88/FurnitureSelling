using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingInfra.Repos;
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
        public Task<List<UpdateCartItemDTO>> GetAllCartItem(int CartId);
        public Task CreateCartItem(CreateCartItemDTO dto);
        public Task UpdateCartItem(UpdateCartItemDTO dto);
        public Task DeleteCartItem(int Id);
    }
}
