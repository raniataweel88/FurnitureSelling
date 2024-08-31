using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FurnitureSellingInfra.Services
{
    public class CartServices : ICartServices

    {
        private readonly ICartRepos _repose;
        public CartServices(ICartRepos repose)
        {
            _repose = repose;
        }

        public async Task<CardCartDTO> GetByIdCart(int Id)
        {
            Log.Debug("start GetByIdCart-Services", Id);

            return await _repose.GetByIdCart_Repose(Id);
        }
        public async Task<List<Cart>> GetAllCart(int UserId)
        {
            Log.Debug("start GetAllCart-Services");

            return await _repose.GetAllCart_Repose(UserId);
        }
        public async Task<int> CreateCart(CartDTO dto)
        {
            Log.Debug("start CreateCart-Services");


            Cart c = new Cart
            {
                IsActiveId = dto.IsActiveId,
                UserId = dto.UserId,
            };
           return  await _repose.CreateCart_Repose(c);

      

            Log.Debug("finished CreateCart-Services");
        }

            public async Task UpdateCart(CardCartDTO C)
        {
            Log.Debug("start UpdateCart-Services", C.CartId);

            await _repose.UpdateCart_Repose(C);
        }
      

        public async Task DeleteCart(int Id)
        {
            Log.Debug("start DeleteCart-Services", Id);

            await _repose.DeleteCart_Repose(Id);
        }

        


}


}
