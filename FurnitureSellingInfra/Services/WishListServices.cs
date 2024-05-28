using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class WishListServices : IWishListServices
    {
        public Task CreateWishList(WishListDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWishList(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CardWishListDTO> GetAllWishList()
        {
            throw new NotImplementedException();
        }

        public Task<WishListDTO> GetByIdWishList(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWishList(WishListDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
