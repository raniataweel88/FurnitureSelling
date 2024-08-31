
using FurnitureSellingCore.DTO.ItemRequest;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IItemRequestRepos
    {
        public Task<ItemRequestDTO> GetByIdItemRequest(int id);
        public Task<List<CardItemRequestDTO>> GetAllItemRequest();
        public Task<List<CardItemRequestDTO>> GetAllItemRequestforuser(int userID);

        public Task CreateItemRequest_Repose(ItemRequest ir);
        public Task UpdateItemRequest(CardItemRequestDTO ir);
        public Task DeleteItemRequest(int id);
        public Task UpdateItemFromAdmain(ItemRequestFromAdmain dto);



    }
}
