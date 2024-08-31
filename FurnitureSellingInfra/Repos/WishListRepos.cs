using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.WishList;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
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
                Log.Debug("finished to  GetByIdWishList_Repose");
                return w;
            }
            else
            {
                Log.Error("cann't found this Wishlist");

                throw new Exception("cann't found this Wishlist");
            }

        }
        public async Task<List<WishListDTO>> GetAllWishList_Repose(int userId)
            {
            Log.Debug("start to  GetAllWishList_Repose");           
            var query = from wl in _context.WishList    
                        join u in _context.Users    
                        on wl.UserId equals u.UserId        
                        where wl.UserId == userId
                        select new WishListDTO
                        { 
                            WishListId= wl.WishListId,
                            ItemId = wl.ItemId,
                            UserId = wl.UserId,
                        };
            Log.Debug("finished to  GetAllWishList_Repose");
            return query.ToList();
        }
        public async Task CreateWishList_Repose(WishList wl)
        {  
            Log.Debug("start to  CreateWishList_Repose");
            var wish=await _context.WishList.Where(x=>x.UserId==wl.UserId).ToListAsync(); 
        
            if (!wish.Any(x=>x.ItemId==wl.ItemId))
            {
             _context.WishList.Add(wl);
             await _context.SaveChangesAsync();
            Log.Debug("finished to  CreateWishList_Repose");
            }
            else
            {
                throw new Exception("this item aready exiest");
            }

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
            Log.Debug("Start to DeleteWishList_Repose");

            var wl = await _context.WishList.FirstOrDefaultAsync(x => x.ItemId == Id);

            if (wl != null)
            {
                _context.WishList.Remove(wl);

                await _context.SaveChangesAsync();

                Log.Information("Item with Id {Id} successfully deleted from wishlist", Id);
            }
            else
            {
                Log.Error("Cannot find the wishlist item with Id {Id}", Id);

                throw new Exception($"Cannot find the wishlist item with Id {Id}");
            }

            Log.Debug("Finished DeleteWishList_Repose");
        }
    }
}
