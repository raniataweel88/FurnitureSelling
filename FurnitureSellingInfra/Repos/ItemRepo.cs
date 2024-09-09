using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using System;


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
            Log.Debug("Start to GetByIdItem_Repose");
            var item = await _context.Items
                    .Where(i => i.ItemId == Id)
                    .FirstOrDefaultAsync();

            if (item == null)
            {
                Log.Information("Item not found");
                return null;
            }
            var result = new DetailsItemDTO
            {
                ItemId = item.ItemId,
                Name = item.Name,
                Description = item.Description,
                Image = $"https://localhost:7148/Images/{item.Image}",
                DisacountAmount = item.DisacountAmount,
                isHaveDiscount = item.isHaveDiscount,
                Price = item.Price,
                DiscountType = item.DiscountType,
                Quantity = item.Quantity,
                CategoryId = item.CategoryId,
                Colors = item.Colors,
                Sizes = item.Sizes,
                EndDate = item.EndDate,
                RestQuantity = item.RestQuantity,
                PriceAfterDiscount = item.PriceAfterDiscount
            };
            DateTime utcNow = DateTime.UtcNow;


            if (item.EndDate.HasValue && item.EndDate.Value <= utcNow)
            {
                item.isHaveDiscount = false;
                item.DisacountAmount = 0;
                item.DiscountType = null;
                item.PriceAfterDiscount = item.Price;
                item.EndDate = null;
                _context.Update(item);
                await _context.SaveChangesAsync();
            }


            else if (item.EndDate.HasValue){

                result.Price = (float)item.PriceAfterDiscount;

            }



            // تحويل الكائن `Item` إلى `DetailsItemDTO`


            Log.Information("Returning Item");
            Log.Debug("Finished GetByIdItem_Repose");

            return result;
        }
    
        public async Task<List<CardItemDTO>> GetAllItem_Repose()
        {
            Log.Debug("start to  GetAllItem_Repose");

            var Query = from i in _context.Items
                        select new CardItemDTO
                        {
                            Name = i.Name,
                            Image = $"https://localhost:7148/Images/{i.Image}",
                            Price = i.Price,
                            ItemId = i.ItemId,
                            catogeryId = i.CategoryId,


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
            var it = _context.Items.Find(t.ItemId);
            Log.Debug("start to UpdateCategory_Repose");

            if (t.Name != null)
            {
                it.Name = t.Name;

                if (t.Description != null)
                    it.Description = t.Description;

                if (t.Image != null && t.Image.Contains("https://localhost:7148/Images/"))
                {
                    it.Image = t.Image.Replace("https://localhost:7148/Images/", "");
                }
                else
                {
                    it.Image = t.Image;
                }
                if (t.RestQuantity != null)
                    it.RestQuantity = (int)t.RestQuantity;

                it.Quantity = (int)t.Quantity;
                it.DateAdd = it.DateAdd;
                it.Price = (float)t.Price;
                it.Colors = t.Colors;
                it.Sizes = t.Sizes;


                if (t.isHaveDiscount == true)
                {
                    {
                        DiscountItemDTO d = new DiscountItemDTO
                        {
                            ItemId = t.ItemId,
                            DisacountAmount = t.DisacountAmount,
                            DiscountType = t.DiscountType,
                            isHaveDiscount = t.isHaveDiscount,
                            EndDate = t.EndDate

                        };
                        await DiscountItem(d);
                    }

                    if (it.CategoryId != t.CategoryId)
                        it.CategoryId = t.CategoryId;

                    _context.Update(it);
                    await _context.SaveChangesAsync();

                    Log.Debug("Finish to UpdateCategory_Repose");

                    _context.Update(it);
                    await _context.SaveChangesAsync();

                    Log.Debug("Finish to  UpdateCategory_Repose");
                }
            }
        }

        public async Task<List<DetailsItemDTO>> SearchItem(string? name, string? description, float? price)
        {
            Log.Debug("start to SearchItem_Repose");

            // استخدم IQueryable لتصفية البيانات على مستوى قاعدة البيانات
            IQueryable<Item> query = _context.Items;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.Contains(name));

            }

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(x => x.Description.Contains(description));
            }

            if (price.HasValue)
            {
                query = query.Where(x => x.Price == price.Value);
            }

            var items = await query.ToListAsync();

            var result = items.Select(i => new DetailsItemDTO
            {
                ItemId = i.ItemId,
                Description = i.Description,
                Name = i.Name,
                Price = i.Price,
                Image = $"https://localhost:7148/Images/{i.Image}",
                CategoryId = i.CategoryId,
                DisacountAmount = i.DisacountAmount,
                DiscountType = i.DiscountType,
                isHaveDiscount = i.isHaveDiscount,
                Quantity = i.Quantity,

            }).ToList();

            Log.Debug("finished to SearchItem_Repose");

            return result;
        }

        public async Task DeleteItem(int Id)
        {
            var i = _context.Items.FirstOrDefault(x => x.ItemId == Id);
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
    
            public async Task<List<DetailsItemDTO>> FilterProducts(ProductFilterDto filter) { 
            var query = await _context.Items.ToListAsync();

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filter.MinPrice.Value).ToList();
            }
            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filter.MaxPrice.Value).ToList();
            }

            if (filter.Color == "All")
            {

                query = query.ToList();
            }
            if (!string.IsNullOrEmpty(filter.Color) && filter.Color != "All")
            {
                Log.Information("Filtering items with color: {Color}", filter.Color);

                query = query.Where(p => p.Colors.Any(c => c == filter.Color)).ToList();
            }

            if (filter.HasDiscount == true)
            {
                query = query.Where(p => p.isHaveDiscount == true).ToList(); ;
            }

            switch (filter.SortBy)
            {

                case "Newness":
                    query = query.OrderByDescending(p => p.DateAdd).ToList(); ;
                    break;
                case "Price: Low to High":
                    query = query.OrderBy(p => p.Price).ToList();
                    break;
                case "Price: High to Low":
                    query = query.OrderByDescending(p => p.Price).ToList();
                    break;
                default:
                    query = query.OrderBy(p => p.Name).ToList(); ;
                    break;
            }
            switch (filter.price)
            {
                case "0-50":
                    query = query.Where(x => x.Price >= 0 && x.Price <= 50).ToList();
                    break;
                case "50-100":
                    query = query.Where(x => x.Price > 50 && x.Price <= 100).ToList();
                    break;
                case "100-150":
                    query = query.Where(x => x.Price > 100 && x.Price <= 150).ToList();
                    break;
                case "150-200":
                    query = query.Where(x => x.Price > 150 && x.Price <= 200).ToList();
                    break;
                case "200+":
                    query = query.Where(x => x.Price > 200).ToList();
                    break;
                default:
                    break;
            }
            var result = query.Select(i => new DetailsItemDTO
            {
                ItemId = i.ItemId,
                Description = i.Description,
                Name = i.Name,
                Price = i.Price,
                Image = $"https://localhost:7148/Images/{i.Image}",
                CategoryId = i.CategoryId,
                DisacountAmount = i.DisacountAmount,
                DiscountType = i.DiscountType,
                isHaveDiscount = i.isHaveDiscount,
                Quantity = i.Quantity,
                Colors = i.Colors,
                Sizes = i.Sizes,


            });

            Log.Debug("finished to SearchItem_Repose");

            return result.ToList();


        }
    
    
    public async Task DiscountItem(DiscountItemDTO d)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.ItemId == d.ItemId);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            // تحديث تفاصيل الخصم
            item.isHaveDiscount = d.isHaveDiscount;
            item.DisacountAmount = d.DisacountAmount;
            item.DiscountType = d.DiscountType;
            item.EndDate = d.EndDate;

            if (item.EndDate.HasValue && item.EndDate.Value < DateTime.UtcNow)
            {
                item.isHaveDiscount = false;
                item.DisacountAmount = 0;
                item.DiscountType = null;
                item.PriceAfterDiscount = item.Price;
            }
            else
            {
                float discountAmount = 0;


                if (item.DiscountType == "Percentage")
                {
                    discountAmount = item.Price * ((float)item.DisacountAmount / 100);
                }
                else
                {
                    discountAmount = (float)item.DisacountAmount;
                }

                item.PriceAfterDiscount = item.Price - discountAmount;
            }

            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }

   
        }

    