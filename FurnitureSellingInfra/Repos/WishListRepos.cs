using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class WishListRepos : IWishListRepos
    {
        public Task CreateWishList_Repose(WishList dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<WishList>> GetAllWishList_Repose()
        {
            throw new NotImplementedException();
        }

        public Task<WishList> GetByIdWishList_Repose(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWishList_Repose(WishList dto)
        {
            throw new NotImplementedException();
        }
    }
}
