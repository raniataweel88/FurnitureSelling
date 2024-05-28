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
        public Task CreateWishList_Repose(WishList dto);

        public Task<WishList> GetByIdWishList_Repose(int Id);
        public Task<List<WishList>> GetAllWishList_Repose();
        public Task UpdateWishList_Repose(WishList dto);
    }
}
