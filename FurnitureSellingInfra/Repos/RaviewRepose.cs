using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Rating;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class RaviewRepose:IRatingRepose
    {
        private readonly FurnitureSellingDbContext _context;
        public RaviewRepose(FurnitureSellingDbContext context) 
        {
        _context = context;
        }
        public async Task<CradRaviewDTO> GetByIdRating_Repose(int Id)
        {
            var r = _context.Raviews.FirstOrDefault(r => r.Id == Id);
            var u = _context.Users.FirstOrDefault(r => r.UserId == r.UserId);
            var i = _context.Items.FirstOrDefault(r => r.ItemId == r.ItemId);
            CradRaviewDTO c = new CradRaviewDTO()
            {
                Review = r.Review,
                Id = r.Id,
                RatingNumber = r.RatingNumber,
                Name = u.FirstName + u.LastName,
                Item = i.Name
            };
            return c;
        }
        public Task<List<CradRaviewDTO>> GetAllRating_Repose()
        {
        var q=from i in _context.Raviews
              from r in _context.Users
              from it in _context.Items
              where i.UserId == r.UserId
              && it.ItemId ==i.ItemId
             select new CradRaviewDTO{
                Id = i.Id,
                RatingNumber = i.RatingNumber,
                Review = i.Review,
                ItemId = i.ItemId,
                UserId = i.UserId,
                Name=r.FirstName+" "+r.LastName,
                Item=it.Name       
            };
      return q.ToListAsync(); 
        }

        public async Task CreateRating_Repose(Raview r)
        {var i=_context.Items.FirstOrDefault(r => r.ItemId==r.ItemId);
            var ct = _context.CartItems.FirstOrDefault(x => x.ItemId == i.ItemId);
            var c = _context.Carts.FirstOrDefault(r => r.CartId == ct.CartId);
            var o = _context.Orders.FirstOrDefault(r => r.OrderId == c.OrderId);
            if (o.StatusDelivery == true)
            {
                _context.Raviews.Add(r);
                 await _context.SaveChangesAsync(); 
            }
       

        }

      

    

        public async Task UpdateRating_Repose(CradRaviewDTO dto)
        {
            var r= await _context.Raviews.FindAsync(dto.Id);

            Log.Debug("start to  UpdateRating_Repose ");

            if (r != null)
            {
                r.Id = dto.Id;
                r.Review = dto.Review;
                r.UserId = dto.UserId;
                r.RatingNumber = dto.RatingNumber;
                r.RatingDate=DateTime.Now;
                r.ItemId = dto.ItemId;
                _context.Update(r);
                await _context.SaveChangesAsync();
                Log.Information("Update this Rating");
            }
            else
            {
                Log.Error("can not found this Rating");
                throw new Exception("can not found this Rating");
            }
            Log.Debug("finished to  UpdateOrder_Repose");

        }
        public async Task DeleteRating_Repose(int Id)
        {
            var rating = _context.Raviews.FirstOrDefault(x => x.Id == Id);

            Log.Debug("start to  DeleteRating_Repose");
            if (rating != null)
            {

                _context.Remove(rating);
                await _context.SaveChangesAsync();
                Log.Information("delete this rating");
            }
            else
            {
                Log.Error("can not found this rating");
                throw new Exception("can not found this rating");
            }
            Log.Debug("Finished to Deleterating_Repose");
        }
    }
}

