using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    public class CartItemServices : ICartItemServices
    {
        private readonly ICartItemRepose _repose;
        public CartItemServices(ICartItemRepose repose)
        {
            _repose = repose;
        }
         public  async Task<CartItemDTO> GetByIdCartItem(int Id)
        {
           return  await _repose.GetByIdCartItem_Repose(Id);
        }
        public async Task<List<CartItemDTO>> GetAllCartItem()
        {
            return await _repose.GetAllCartItem_Repose();
        }
        public async Task CreateCartItem(CreateCartItemDTO dto)
        {
            CartItem c = new CartItem()
            {
                CartId = dto.CartId,
                Quantity = dto.Quantity,
                ItemId = dto.ItemId,
            };
           await _repose.CreateCartItem_Repose(c);
          
  }
        public async  Task UpdateCartItem(CartItemDTO dto)
        {
            await _repose.UpdateCartItem_Repose(dto);
        }
        public async Task DeleteCartItem(int Id)
        {
            await _repose.DeleteCartItem_Repose(Id);        }

    }
}
