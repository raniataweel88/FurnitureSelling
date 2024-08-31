using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
            Log.Debug("start GetByIdCartItem-Services", Id);

            return await _repose.GetByIdCartItem_Repose(Id);
        }
        public async Task<List<UpdateCartItemDTO>> GetAllCartItem(int userId)
        {
            Log.Debug("start GetAllCartItem-Services");

            return await _repose.GetAllCartItem_Repose(userId);
        }
        public async Task CreateCartItem(CreateCartItemDTO dto)
        {
            Log.Debug("start CreateCartItem-Services");

            CartItem c = new CartItem()
            {
                CartId = dto.CartId,
                Quantity = dto.Quantity,
                ItemId = dto.ItemId,
                Color=dto.Color,
                Size=dto.Size,  

            };
           await _repose.CreateCartItem_Repose(c);
          
  }
        public async  Task UpdateCartItem(UpdateCartItemDTO dto)
        {
            Log.Debug("start update-Services");

            await _repose.UpdateCartItem_Repose(dto);
        }
        public async Task DeleteCartItem(int Id)
        {
            Log.Debug("start delete cart item-Services", Id);

            await _repose.DeleteCartItem_Repose(Id);    
        }

    }
}
