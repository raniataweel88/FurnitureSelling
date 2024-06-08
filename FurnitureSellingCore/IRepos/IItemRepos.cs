 using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IItemRepos
    { 
        public Task<DetailsItemDTO> GetByIdItem_Repose(int id);
        public Task<List<CardItemDTO>> GetAllItem_Repose();
        public Task CreateItem_Repose(Item t);
        public Task UpdateItem(DetailsItemDTO t);
        public Task<List<DetailsItemDTO>> SearchItem(string? name, string? description, float? price);

        public Task DeleteItem(int Id);

    }
}
