
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
        public Task CreateItemRequest_Repose(ItemRequest ir);
        public Task<ItemRequest> GetByIdItemRequest(int id);
        public Task<List<ItemRequest>> GetAllItemRequest();
        public Task UpdatetemRequest(ItemRequest ir);


    }
}
