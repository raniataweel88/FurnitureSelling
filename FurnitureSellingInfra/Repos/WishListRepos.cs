using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Mysqlx;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class WishListRepos : IWishListRepos
    {
        private readonly FurnitureSellingDbContext _context;
        public WishListRepos(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        public async Task<WishListDTO> GetByIdWishList_Repose(int Id)
        {
            Log.Debug("start to  GetByIdWishList_Repose");

            var wl =_context.WishList.FirstOrDefault(x=>x.WishListId == Id);
            if(wl != null)
            {
            WishListDTO w = new WishListDTO();
            w.WishListId=wl.WishListId ; 
            w.ItemId = wl.ItemId;
            w.UserId = wl.UserId;
            return w;
            }
            else
            {
                Log.Error("cann't found this Wishlist");

                throw new Exception("cann't found this Wishlist");
            }
            Log.Debug("finished to  GetByIdWishList_Repose");


        }
        public async Task<List<WishListDTO>> GetAllWishList_Repose()
        {
            Log.Debug("start to  GetAllWishList_Repose");

            var query = from wl in _context.WishList
                        select new WishListDTO
                        { 
                            WishListId= wl.WishListId,
                            ItemId = wl.ItemId,
                            UserId = wl.UserId,
                        };
            
            return query.ToList();
            Log.Debug("finished to  GetAllWishList_Repose");

        }
        public async Task CreateWishList_Repose(WishList wl)
        {
            Log.Debug("start to  CreateWishList_Repose");
            
            _context.WishList.Add(wl);
        await _context.SaveChangesAsync();
            Log.Debug("finished to  CreateWishList_Repose");

        }

        public async Task UpdateWishList_Repose(WishListDTO d)
        {
            Log.Debug("start to  UpdateWishList_Repose");
            var w= _context.WishList.Find(d.WishListId);

            w.ItemId = d.ItemId;
                w.UserId = d.UserId;
            w.WishListId = d.WishListId;
               
                _context.Update(w);
           await  _context.SaveChangesAsync();
              
            Log.Debug("finished to  UpdateWishList_Repose");

        }

        public async Task DeleteWishList_Repose(int Id)
        {
            Log.Debug("start to  DeleteWishList_Repose");

            var wl = _context.WishList.FirstOrDefault(x => x.WishListId == Id);
            if (wl != null)
            {
                _context.WishList.Remove(wl);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("cann't found this Wishlist");

                throw new Exception("cann't found this Wishlist");
            }
            Log.Debug("finished to  DeleteWishList_Repose");

        }
    }
}
