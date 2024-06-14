using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Serilog;
using System;
using System.Collections.Generic;
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
                Price=dto.Price,
                Color = dto.Color,
                Size = dto.Size,

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
    }
}
