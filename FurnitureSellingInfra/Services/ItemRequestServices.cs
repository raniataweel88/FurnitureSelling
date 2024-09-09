using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using Serilog;
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
        public async Task<CardItemRequestDTO> GetByIdItemRequest(int Id)
        {
            Log.Debug("start GetByIdItemRequest-Services", Id);
            return await _Repose.GetByIdItemRequest(Id);  
        }
        public async Task<List<CardItemRequestDTO>> GetAllItemRequest()
        {
            Log.Debug("start GetAllItemRequest-Services");
            return await _Repose.GetAllItemRequest();
        }
        public async Task CreateItemRequest(ItemRequestDTO dto)
         {
            Log.Debug("start CreateItemRequest-Services");

            ItemRequest ir = new ItemRequest
            {
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                CategoryId = 21, 
             UserId = dto.UserId,

            };
            await  _Repose.CreateItemRequest_Repose(ir);
        }   
        public async Task UpdateItemRequest(CardItemRequestDTO dto)
        {
            Log.Debug("start GetByIdItemRequest-Services", dto.ItemRequestId);
            await _Repose.UpdateItemRequest(dto);
        }
        public async Task DeleteItemRequest(int Id)
        {
            Log.Debug("start DeleteItemRequest-Services", Id);
            await _Repose.DeleteItemRequest(Id);
        }

        public  async Task UpdateItemFromAdmain(ItemRequestFromAdmain dto)
        {
            Log.Debug("start UpdateItemFromAdmain-Services", dto.ItemRequestId);

           await  _Repose.UpdateItemFromAdmain(dto);   
        }

        public async Task<List<CardItemRequestDTO>> GetAllItemRequestfromuser(int userId)
        {
            Log.Debug("start GetAllItemRequest-Services");
            return await _Repose.GetAllItemRequestforuser(userId);
        }
    }
}
