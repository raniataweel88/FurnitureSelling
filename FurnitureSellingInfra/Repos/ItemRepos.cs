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
            Log.Information("ftart to  GetByIdItem_Repose");
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
            Log.Information("finised to  GetByIdItem_Repose");
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
            Log.Information("finised to  GetAllItem_Repose");
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
                Log.Error("the Item is emptyee");
                throw new Exception("the Item is emptyee");
            }
            Log.Information("finised to  CreateItem_Repose");
        }

        public async Task Updatetem(DetailsItemDTO t)
        {
            Log.Information("strart to  UpdateCategory_Repose");
            Item i = new Item()
            {
                ItemId = t.ItemId,
                Name = t.Name,
                Description = t.Description,
                Image = t.Image,
                DisacountAmount = t.DisacountAmount,
                Price = t.Price,
                DiscountType = t.DiscountType,
                Quantity = t.Quantity,
                CategoryId = t.CategoryId

            };
            _context.Update(i);
            _context.SaveChanges();

            Log.Information("finised to  UpdateCategory_Repose");
    } 

        public Task Searchitem<Item>(string? Name, string? Category, int? price)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteItem(int id)
        {
         var i=_context.Items.FirstOrDefaultAsync(x=>x.ItemId==id);
            if (i != null)
            {
                Log.Information("start to  DeleteItem");
                if (i != null)
                {
                    Log.Information("found this Item");
                    _context.Remove(i);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Log.Error("can not found this Item");
                    throw new Exception("can not found this Item");
                }
                Log.Information("Finsid to DeleteItem");
            }
        }
}
        }




