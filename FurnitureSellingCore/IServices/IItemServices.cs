using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IItemServices

    {
        public Task<DetailsItemDTO> GetByIdItem(int id);
        public Task<List<CardItemDTO>> GetAllItem();
        public Task CreateItemServices(CreateItemDTO dto);
        public Task Updateitem(DetailsItemDTO dto);
        public Task<List<DetailsItemDTO>> SearchItem(string? name, string? discerption, float? price);
        public Task DeleteItem(int id);
        public Task DiscountItem(DiscountItemDTO d);


    }
}
