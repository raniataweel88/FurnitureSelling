using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class ItemRequestServices : IItemRequestServices
    {
        public Task CreateItemRequest(ItemRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CardItemRequestDTO> GetAllItemRequest()
        {
            throw new NotImplementedException();
        }

        public Task<ItemRequestDTO> GetByIdItemRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatetemRequest(ItemRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
