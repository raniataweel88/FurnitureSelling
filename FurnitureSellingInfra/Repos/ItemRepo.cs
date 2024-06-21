using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MySqlX.XDevAPI.Common;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
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
        public async Task<DetailsItemDTO> GetByIdItem_Repose(int Id)
        {
            Log.Debug("start to  GetByIdItem_Repose");
          var Query=from i in _context.Items  
                    where i.CategoryId == Id
                    select new DetailsItemDTO
            {
                        ItemId=i.ItemId,
                Name = i.Name,
                Description = i.Description,
                Image=i.Image,
                DisacountAmount=i.DisacountAmount,
                isHaveDiscount=i.isHaveDiscount,
                Price= i.Price,
                DiscountType=i.DiscountType,
                Quantity =i.Quantity,
                CategoryId= i.CategoryId,
          
                    };
            Log.Information("return Item");

            Log.Debug("finished to  GetByIdItem_Repose");

            return Query.FirstOrDefault();         
        }
        public async Task<List<CardItemDTO>> GetAllItem_Repose()
        {
            Log.Debug("start to  GetAllItem_Repose");

            var Query = from i in _context.Items
                        select new CardItemDTO
                        {
                            Name = i.Name,
                            Image = i.Image,
                            Price = i.Price,
                            ItemId = i.ItemId,

                        };
            Log.Information("return all Item");

            Log.Debug("finished to  GetAllItem_Repose");

            return Query.ToList();
        }
        public async Task CreateItem_Repose(Item ct)
        {
           
            Log.Debug("start to  CreateItem_Repose");
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
            Log.Debug("finished to  CreateItem_Repose");
        }

        public async Task UpdateItem(DetailsItemDTO t)
        {
            var it =  _context.Items.Find(t.ItemId);
            Log.Debug("start to  UpdateCategory_Repose");
            
            it.ItemId= t.ItemId;
            it.Name = t.Name;
            it.Description = t.Description;     
                it.Image = t.Image;
                it.Quantity = t.Quantity;
            it.Price = t.Price;
            it.isHaveDiscount= t.isHaveDiscount;    
            it.DisacountAmount= t.DisacountAmount;
            it.DiscountType= t.DiscountType;
            DiscountItemDTO d = new DiscountItemDTO();
            if ((bool)t.isHaveDiscount)
            {
                d.ItemId= t.ItemId;
               d.DisacountAmount = t.DisacountAmount;
               d.DiscountType = t.DiscountType;
                d.isHaveDiscount= t.isHaveDiscount;
               await  DiscountItem(d);
            }
            it.CategoryId = t.CategoryId;
                _context.Update(it);
            await _context.SaveChangesAsync();

            Log.Debug("Finish to  UpdateCategory_Repose");
    } 

        public async Task<List<DetailsItemDTO>> SearchItem(string? name, string? description, float? price)
        {
            Log.Debug("start to  SearchItem_Repose");

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
            Log.Debug("finished to  SearchItem_Repose");

            return (  result.ToList());

        }

        public async Task DeleteItem(int Id)
        {
         var i=_context.Items.FirstOrDefault(x=>x.ItemId== Id);
            if (i != null)
            {
                Log.Debug("start to  DeleteItem");
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
                Log.Debug("Finish to DeleteItem");
            }
        }
        public async Task DiscountItem(DiscountItemDTO d)
        {
            var item = _context.Items.FirstOrDefault(x => x.ItemId == d.ItemId);
            item.isHaveDiscount=d.isHaveDiscount;
            item.DisacountAmount=d.DisacountAmount;
            item.DiscountType=d.DiscountType;
            item.EndDate=d.EndDateOfDiscount;
           
            float des = 0;
                if (item.DiscountType == 0)
                {

                  des=  item.Price*((float)item.DisacountAmount / 100); 
                item.Price-= des;
                _context.Update(item);
               await _context.SaveChangesAsync();
                }
                else
                {
                des= (float)item.DisacountAmount;
                item.Price -= des;
              
                _context.Update(item);
               await _context.SaveChangesAsync();
                }
            if (item.EndDate <= DateTime.UtcNow)
            {
                item.Price += des;
            }
            }
          
        }
    }
        



