using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IWishListRepos
    {  
        public Task<WishListDTO> GetByIdWishList_Repose(int Id);
        public Task<List<WishListDTO>> GetAllWishList_Repose();
        public Task CreateWishList_Repose(WishList w);
        public Task UpdateWishList_Repose(WishList w);
        public Task DeleteWishList_Repose(int id);

    }
}
