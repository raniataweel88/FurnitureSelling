using FurnitureSellingCore .Context;
using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class ItemRequestRepos : IItemRequestRepos
    {
        private readonly FurnitureSellingDbContext _context;
        public ItemRequestRepos(FurnitureSellingDbContext context)
        {
            _context = context;

        }
        public async Task<ItemRequestDTO> GetByIdItemRequest(int id)
        {
            Log.Information("start to  GetByIdItemRequest");
            var query = from i in _context.ItemRequests
                        where i.Id == id
                        select new ItemRequestDTO
                        {
                            Image = i.Image,
                            Title = i.Title,
                            Description = i.Description,
                            CategoryId = i.CategoryId,
                        };
                return query.FirstOrDefault();
            Log.Information("finished to  GetByIdItemRequest");
        }
        public async Task<List<CardItemRequestDTO>> GetAllItemRequest()
        {
            Log.Information("start to  GetAllItemRequest");

            var Query = from ir in _context.ItemRequests
                        select new CardItemRequestDTO()
                        {
                            Title = ir.Title,
                            Image = ir.Image,
                            ItemRequestId = ir.Id,
                            Description = ir.Description,
                            CategoryId = ir.CategoryId,
                        };
            return Query.ToList();
            Log.Information("finished to  GetAllItemRequest");

        }

        public async Task CreateItemRequest_Repose(ItemRequest ir)
        {
            Log.Information("start to  CreateItemRequest_Repose");
            if (ir != null)
            {
                Log.Information("the ItemRequest not null");
                await _context.ItemRequests.AddAsync(ir);
                
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("the ItemRequest is empty");
                throw new Exception("the ItemRequest is empty");
            }
            Log.Information("finished to  CreateItemRequest_Repose");
        }

        public async Task UpdateItemRequest(CardItemRequestDTO dto)
        {
            var i =await _context.ItemRequests.FindAsync(dto.ItemRequestId);
            Log.Information("start to  UpdateItemRequest_Repose");
            if (i != null)
            {

                i.Title = dto.Title;
                i.Description = dto.Description;
                i.Image = dto.Image;
                i.CategoryId = dto.CategoryId;
                i.Id = dto.ItemRequestId;
                _context.Update(i);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this Category");
                throw new Exception("can not found this Category");
            }
            Log.Information("finished to  UpdateCategory_Repose_Repose");

        }

        public async Task DeleteItemRequest(int id)
        {
            Log.Information("start to  DeleteItemRequest_Repose");
            var ir = await _context.ItemRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (ir != null)
            {
                Log.Information("found this ItemRequest");
                _context.ItemRequests.Remove(ir);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this ItemRequest");
                throw new Exception("can not found this ItemRequest");
            }
            Log.Information("Finished to DeleteItemRequest_Repose");
        }
        public  float Total()
        {

            return 4;
        }

    }
}
