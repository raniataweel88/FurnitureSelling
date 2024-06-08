using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
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
        public async Task<DetailsItemDTO> GetByIdItem(int id)
        {

          return  await _Repos.GetByIdItem_Repose(id);


        }
        public async Task<List<CardItemDTO>> GetAllItem()
        {
           return await _Repos.GetAllItem_Repose();
        }
        public async Task CreateItemServices(CreateItemDTO dto)
        {
            Item i = new Item()
            {
                Name = dto.Name,
                Description = dto.Description,
                Image = dto.Image,
                CategoryId = dto.CategoryId,
                Price=dto.Price,


            };
            await _Repos.CreateItem_Repose(i);   
        }

        public async Task<List<DetailsItemDTO>> SearchItem(string? name, string? discerption, float? price)
        {
                return await _Repos.SearchItem(name,discerption,price);
        }

        public async Task Updateitem(DetailsItemDTO dto)
        {
            await _Repos.UpdateItem(dto);
        }
        public async Task DeleteItem(int id)
        {
            await _Repos.DeleteItem(id);
        }
    }
}
