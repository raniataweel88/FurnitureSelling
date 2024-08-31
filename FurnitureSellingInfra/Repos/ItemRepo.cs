using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;


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
            var Query = from i in _context.Items
                        where i.ItemId == Id
                        select new DetailsItemDTO
                        {
                            ItemId = i.ItemId,
                            Name = i.Name,
                            Description = i.Description,
                            Image = $"https://localhost:7148/Images/{i.Image}",
                            DisacountAmount = i.DisacountAmount,
                            isHaveDiscount = i.isHaveDiscount,
                            Price = i.Price,
                            DiscountType = i.DiscountType,
                            Quantity = i.Quantity,
                            CategoryId = i.CategoryId,
                            Colors = i.Colors,
                            Sizes = i.Sizes,
                            EndDate = i.EndDate,
                            RestQuantity = i.RestQuantity,
                            PriceAfterDiscount = i.PriceAfterDiscount

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

            if (it.Name != t.Name)
                it.Name = t.Name;

            if (it.Description != t.Description)
                it.Description = t.Description;

            if (t.Image != null && t.Image.Contains("https://localhost:7148/Images/"))
            {
                it.Image = t.Image.Replace("https://localhost:7148/Images/", "");
            }
            else
            {
                it.Image = t.Image;
            }


            if (it.Quantity != t.Quantity)
                it.Quantity = (int)t.Quantity;

            if (it.Price != t.Price)
                it.Price = (float)t.Price;

            if (it.isHaveDiscount != t.isHaveDiscount)
                it.isHaveDiscount = t.isHaveDiscount;

            if (it.DisacountAmount != t.DisacountAmount)
                it.DisacountAmount = t.DisacountAmount;

            if (it.DiscountType != t.DiscountType)
                it.DiscountType = t.DiscountType;

            if (it.Colors != t.Colors)
                it.Colors = t.Colors;

            if (it.Sizes != t.Sizes)
                it.Sizes = t.Sizes;

            if (it.EndDate != t.EndDate)
                it.EndDate = t.EndDate;

            if ((bool)t.isHaveDiscount)
            {
                DiscountItemDTO d = new DiscountItemDTO
                {
                    ItemId = t.ItemId,
                    DisacountAmount = t.DisacountAmount,
                    DiscountType = t.DiscountType,
                    isHaveDiscount = t.isHaveDiscount
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
        public async Task<List<DetailsItemDTO>> FilterProducts(ProductFilterDto filter)
        {
            var query = await _context.Items.ToListAsync();

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filter.MinPrice.Value).ToList();
            }
            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filter.MaxPrice.Value).ToList();
            }

            if (!string.IsNullOrEmpty(filter.Color))
            {
                Log.Information("Filtering items with color: {Color}", filter.Color);

                query = query.Where(p => p.Colors != null && p.Colors.Any(c => filter.Color.Contains(c))).ToList();
                if (query.Where(p => p.Colors != null && p.Colors.Any(c => filter.Color.Contains(c))) == null)
                    throw new Exception("");
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
                item.DiscountType = 0;
                item.PriceAfterDiscount = item.Price;
            }
            else
            {
                float discountAmount = 0;

                if (item.DiscountType == 0)
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

    