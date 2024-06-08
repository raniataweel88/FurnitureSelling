using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.DTO.WishList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IWishListServices
    {
        public Task<WishListDTO> GetByIdWishList(int Id);
        public Task<List<WishListDTO>>  GetAllWishList();
        public Task CreateWishList(CardWishListDTO dto);

        public Task UpdateWishList(WishListDTO dto);
        public Task DeleteWishList(int Id);
    }
}
