using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.ItemRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IItemRequestServices
    {

        public Task CreateItemRequest(ItemRequestDTO dto);
        public Task DeleteItemRequest(int id);
        public Task<ItemRequestDTO> GetByIdItemRequest(int id);
        public Task<CardItemRequestDTO> GetAllItemRequest();
        public Task UpdatetemRequest(ItemRequestDTO dto);


    }
}
