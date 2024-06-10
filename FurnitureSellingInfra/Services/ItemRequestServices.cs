using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    public class ItemRequestServices : IItemRequestServices
    {
        private readonly IItemRequestRepos _Repose;
        public ItemRequestServices(IItemRequestRepos Repose)
        {
            _Repose = Repose;
        }
        public async Task<ItemRequestDTO> GetByIdItemRequest(int id)
        {
           return  await _Repose.GetByIdItemRequest(id);
           
        }
        public async Task<List<CardItemRequestDTO>> GetAllItemRequest()
        {
            return await _Repose.GetAllItemRequest();
        }
        public async Task CreateItemRequest(ItemRequestDTO dto)
        {
            ItemRequest ir = new ItemRequest
            {
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                CategoryId = dto.CategoryId,
               
            };
           await   _Repose.CreateItemRequest_Repose(ir);
        }   
        public async Task UpdateItemRequest(CardItemRequestDTO dto)
        {
        
            await _Repose.UpdateItemRequest(dto);
        }
        public async Task DeleteItemRequest(int id)
        {
          await  _Repose.DeleteItemRequest(id);    }

   


     
    }
}
