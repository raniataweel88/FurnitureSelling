using FurnitureSellingCore . Context; 
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
        public async Task<CardItemRequestDTO> GetByIdItemRequest(int Id)
        {
            Log.Debug("start to  GetByIdItemRequest");

            var query = from i in _context.ItemRequests
                        where i.Id == Id
                        select new CardItemRequestDTO
                        {
                            Image = $"https://localhost:7148/Images/{i.Image}",
                            Title = i.Title,
                            Description = i.Description,
                            UserId =i.UserId,
                            Note = i.NoteAdmain,
                            price = i.Price,
                            ItemRequestId=i.Id
                        };

            Log.Debug("finished to  GetByIdItemRequest");
            return query.FirstOrDefault();
        }
        public async Task<List<CardItemRequestDTO>> GetAllItemRequest()
        {
            Log.Debug("start to  GetAllItemRequest");

            var Query = from ir in _context.ItemRequests
                        select new CardItemRequestDTO()
                        {
                            Title = ir.Title, 
                            Image = $"https://localhost:7148/Images/{ir.Image}",
                            ItemRequestId = ir.Id,
                            Description = ir.Description,
                            Note = ir.NoteAdmain,
                            price=ir.Price,
                         UserId = ir.UserId
                        };
            Log.Debug("finished to  GetAllItemRequest");
            return Query.ToList();
        }

        public async Task CreateItemRequest_Repose(ItemRequest ir)
        {
            Log.Debug("start to  CreateItemRequest_Repose");
            if (ir != null)
            {

                 Log.Information("add the ItemRequest ");
               await _context.ItemRequests.AddAsync(ir);
                       await _context.SaveChangesAsync();
          
                }
               
            else
            {
                Log.Error("the ItemRequest is empty");
                throw new Exception("the ItemRequest is empty");
            }
            Log.Debug("finished to  CreateItemRequest_Repose");
        }

        public async Task UpdateItemRequest(CardItemRequestDTO dto)
        {
            var i =await _context.ItemRequests.FindAsync(dto.ItemRequestId);
            Log.Debug("start to  UpdateItemRequest_Repose");
            if (i != null)
            {
                i.Title = dto.Title;
                i.Description = dto.Description;
                i.Image = dto.Image;
                i.CategoryId =21;
                i.Id=dto.ItemRequestId;
                _context.Update(i);
                await _context.SaveChangesAsync();
                Log.Information("update this ItemRequest");

            }
            else
            {
                Log.Error("can not found this Category");
                throw new Exception("can not found this Category");
            }
            Log.Debug("finished to  UpdateCategory_Repose_Repose");

        }

        public async Task DeleteItemRequest(int Id)
        {
            Log.Debug("start to  DeleteItemRequest_Repose");
            var ir = await _context.ItemRequests.FirstOrDefaultAsync(x => x.Id==Id);
            if (ir != null)
            {
                Log.Information("delete this ItemRequest");
                _context.ItemRequests.Remove(ir);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this ItemRequest");
                throw new Exception("can not found this ItemRequest");
            }
            Log.Debug("Finished to DeleteItemRequest_Repose");
        }
        public async Task UpdateItemFromAdmain(ItemRequestFromAdmain dto)
        {
            Log.Debug("start to UpdateItemFromAdmain_Repose");
            var ir = await _context.ItemRequests.FirstOrDefaultAsync(x => x.Id == dto.ItemRequestId);
            if (ir != null)
            {
                Log.Information("Update Item From Admain");
                ir.Price = dto.Price;
                ir.NoteAdmain = dto.Note;
                _context.Update(ir);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this ItemRequest");
                throw new Exception("can not found this ItemRequest");
            }
            Log.Debug("Finished to UpdateItemFromAdmain_Repose");
        }

        public async Task<List<CardItemRequestDTO>> GetAllItemRequestforuser(int userId)
        {
            Log.Debug("start to  GetAllItemRequest user");

            var Query = from ir in _context.ItemRequests
                     where ir.UserId == userId
                        select new CardItemRequestDTO()
                        {
                            Title = ir.Title,
                            Image = $"https://localhost:7148/Images/{ir.Image}",
                            ItemRequestId = ir.Id,
                            Description = ir.Description,
                           UserId=ir.UserId,
                            price = ir.Price,

                        };
            Log.Debug("finished to  GetAllItemRequest");
            return Query.ToList();
        }
    }
}
