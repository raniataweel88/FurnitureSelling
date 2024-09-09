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
    public class RaviewRepose: IRaviewRepose
    {
        private readonly FurnitureSellingDbContext _context;
        public RaviewRepose(FurnitureSellingDbContext context) 
        {
        _context = context;
        }
        public async Task<CradRaviewDTO> GetByIdRaview_Repose(int Id)
        {
            var r = _context.Raviews.FirstOrDefault(r => r.Id == Id);
      
       
            CradRaviewDTO c = new CradRaviewDTO()
            {
                Review = r.Review,
                Id = r.Id,
                RatingNumber = r.RatingNumber,
            
            };
            return c;
        }
        public Task<List<CradRaviewDTO>> GetAllRaview_Repose(int ItemId)
        {
        var q=from i in _context.Raviews
              join u in _context.Users
              on i.UserId equals u.UserId   
              join it in _context.Items
              on i.ItemId equals it.ItemId
              where i.ItemId == ItemId
             select new CradRaviewDTO{
                Id = i.Id,
                RatingNumber = i.RatingNumber,
                Review = i.Review,
                ItemId = i.ItemId,
                UserId = i.UserId,
                Name=u.FirstName+" "+u.LastName,
                ratingDate=i.RatingDate,

                ItemName=it.Name,
            };
      return q.ToListAsync(); 
        }

        public async Task CreateRaview_Repose(Raview r)
        {
            
               await _context.Raviews.AddAsync(r);
                 await _context.SaveChangesAsync(); 
            
       

        }

      

    

        public async Task UpdateRaview_Repose(CradRaviewDTO dto)
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
        public async Task DeleteRaview_Repose(int Id)
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

