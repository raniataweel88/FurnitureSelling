using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FurnitureSellingCore.IRepos
{
    public interface ICartItemRepose
    {
        public Task<CartItemDTO> GetByIdCartItem_Repose(int Id);
        public Task<List<UpdateCartItemDTO>> GetAllCartItem_Repose(int CartId);
        public Task CreateCartItem_Repose(CartItem model);
        public Task UpdateCartItem_Repose(UpdateCartItemDTO dto);
        public Task DeleteCartItem_Repose(int id);

    }
}
