using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    public class ItemServices : IItemServices
    {
        private readonly IItemRepos _Repos;
        public ItemServices(IItemRepos Repos)
        {
            _Repos=Repos;
        }
        public async Task<DetailsItemDTO> GetByIdItem(int Id)
        {
            Log.Debug("start GetByIdItem-Services", Id);
            return await _Repos.GetByIdItem_Repose(Id);
        }
        public async Task<List<CardItemDTO>> GetAllItem()
        {
            Log.Debug("start GetAllItem-Services");
            return await _Repos.GetAllItem_Repose();
        }
        public async Task CreateItemServices(CreateItemDTO dto)
        {
            Log.Debug("start CreateItemServices-Services");
            Item i = new Item()
            {
                Name = dto.Name,
                Description = dto.Description,
                Image = dto.Image,
                CategoryId = dto.CategoryId,
                Quantity = (int)dto.Quantity,
                Price =dto.Price,
                Colors= dto.Colors,
                Sizes=dto.Sizes,
                DateAdd=DateTime.Now,
            };
            await _Repos.CreateItem_Repose(i);   
        }

        public async Task<List<DetailsItemDTO>> SearchItem(string? name, string? discerption, float? price)
        {
            Log.Debug("start SearchItem-Services");
            return await _Repos.SearchItem(name,discerption,price);
        }

        public async Task Updateitem(DetailsItemDTO dto)
        {
            Log.Debug("start Updateitem-Services",dto.ItemId);
            await _Repos.UpdateItem(dto);
        }
        public async Task DeleteItem(int Id)
        {
            Log.Debug("start DeleteItem-Services", Id);
            await _Repos.DeleteItem(Id);
        }

        public Task DiscountItem(DiscountItemDTO d)
        {
         return  _Repos.DiscountItem(d);

        }

        public async Task<List<DetailsItemDTO>> FilterProducts(ProductFilterDto filter)
        {
        return await   _Repos.FilterProducts(filter);
        }
    }
}
