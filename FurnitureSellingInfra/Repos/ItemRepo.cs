using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class ItemRepos : IItemRepos
    {
        private readonly FurnitureSellingDbContext _context;
        public ItemRepos(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        public async Task<DetailsItemDTO> GetByIdItem_Repose(int id)
        {
            Log.Information("start to  GetByIdItem_Repose");
          var Query=from i in _context.Items  
                    where i.CategoryId == id
                    select new DetailsItemDTO
            {
                Name = i.Name,
                Description = i.Description,
                Image=i.Image,
                DisacountAmount=i.DisacountAmount,
                isHaveDiscount=i.isHaveDiscount,
                Price=i.Price,
                DiscountType=i.DiscountType,
                Quantity = i.Quantity,
                CategoryId= i.CategoryId
               
            };
            return Query.FirstOrDefault();         
            Log.Information("finished to  GetByIdItem_Repose");
        }
        public async Task<List<CardItemDTO>> GetAllItem_Repose()
        {
            Log.Information("start to  GetAllItem_Repose");

            var Query = from i in _context.Items
                        select new CardItemDTO
                        {
                            Name = i.Name,
                            Image = i.Image,
                            Price = i.Price,
                            ItemId = i.ItemId,

                        };
            return Query.ToList();
            Log.Information("finished to  GetAllItem_Repose");
        }
        public async Task CreateItem_Repose(Item ct)
        {
           
            Log.Information("start to  CreateItem_Repose");
            if (ct != null)
            {
                Log.Information("the Item not null");
                await _context.Items.AddAsync(ct);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("the Item is empty");
                throw new Exception("the Item is empty");
            }
            Log.Information("finished to  CreateItem_Repose");
        }

        public async Task UpdateItem(DetailsItemDTO t)
        {
            var it = await _context.Items.FindAsync(t.ItemId);
            Log.Information("start to  UpdateCategory_Repose");
            it.ItemId = t.ItemId;
            it.Name = t.Name;
            it.Description = t.Description;
            it.Image = t.Image;
            it.DisacountAmount = t.DisacountAmount;
            it.Price = t.Price;
            it.DiscountType = t.DiscountType;
            it.Quantity = t.Quantity;
            it.CategoryId = t.CategoryId;
            
            _context.Update(it);
            _context.SaveChanges();

            Log.Information("Finish to  UpdateCategory_Repose");
    } 

        public async Task<List<DetailsItemDTO>> SearchItem(string? name, string? description, float? price)
        {
            Log.Information("start to  SearchItem_Repose");

            var items = await _context.Items.ToListAsync();
            if (name != null)
                items = items.Where(x => x.Name.Contains(name)).ToList();
            if (description != null)
                items = items.Where(x => x.Description.Contains(description)).ToList();
            if (price != null)
                items = items.Where(x => x.Price.Equals(price)).ToList();
            var result = from i in items
                         select new DetailsItemDTO
                         {
                             ItemId= i.ItemId,
                             Description = i.Description,
                             Name = i.Name,
                             Price= i.Price,
                             Image = i.Image,   
                             CategoryId= i.CategoryId,
                             DisacountAmount= i.DisacountAmount,
                             DiscountType= i.DiscountType,
                             isHaveDiscount= i.isHaveDiscount,
                             Quantity= i.Quantity

                         };
            return  (  result.ToList());
            Log.Information("finished to  SearchItem_Repose");

        }

        public async Task DeleteItem(int id)
        {
         var i=_context.Items.FirstOrDefault(x=>x.ItemId==id);
            if (i != null)
            {
                Log.Information("start to  DeleteItem");
                if (i != null)
                {
                    Log.Information("found this Item");
                    _context.Items.Remove(i);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Log.Error("can not found this Item");
                    throw new Exception("can not found this Item");
                }
                Log.Information("Finish to DeleteItem");
            }
        }
}
        }




