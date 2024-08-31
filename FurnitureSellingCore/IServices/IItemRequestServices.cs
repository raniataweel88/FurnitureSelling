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
        public Task<ItemRequestDTO> GetByIdItemRequest(int id);
        public Task<List<CardItemRequestDTO>> GetAllItemRequest();
        public Task<List<CardItemRequestDTO>> GetAllItemRequestfromuser(int userId);

        public Task CreateItemRequest(ItemRequestDTO dto);
        public Task UpdateItemRequest(CardItemRequestDTO dto);
        public Task DeleteItemRequest(int id);
        public  Task UpdateItemFromAdmain(ItemRequestFromAdmain dto);

    }
}
