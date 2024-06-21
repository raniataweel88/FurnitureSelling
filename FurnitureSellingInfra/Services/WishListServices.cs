using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Org.BouncyCastle.Crypto;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    public class WishListServices : IWishListServices
    {
        private readonly IWishListRepos _repose;
        public WishListServices(IWishListRepos repose)
        {
            _repose = repose;
        }
        public async Task<WishListDTO> GetByIdWishList(int Id)
        {
            Log.Debug("start GetByIdWishList-Services", Id);
            return await _repose.GetByIdWishList_Repose(Id);  
        }
        public async Task<List<WishListDTO>> GetAllWishList()
        {
            Log.Debug("start GetAllWishList-Services");
            return await _repose.GetAllWishList_Repose();
        }
        public async Task CreateWishList(CardWishListDTO dto)
        {
            Log.Debug("start CreateWishList-Services");
            WishList w = new WishList
            {
                ItemId = dto.ItemId,
                UserId = dto.UserId,
            };
            await _repose.CreateWishList_Repose(w);
        }

        public async Task UpdateWishList(WishListDTO dto)
        {
            Log.Debug("start UpdateWishList-Services");
       
            await _repose.UpdateWishList_Repose(dto);
        }
        public async Task DeleteWishList(int Id)
        {
            Log.Debug("start DeleteWishList-Services", Id);
            await _repose.DeleteWishList_Repose(Id);   
        
        }
  

     

    }
}
