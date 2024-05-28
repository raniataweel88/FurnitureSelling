using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class ItemRequestRepos : IItemRequestRepos
    {
        public Task CreateItemRequest_Repose(ItemRequest ir)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemRequest>> GetAllItemRequest()
        {
            throw new NotImplementedException();
        }

        public Task<ItemRequest> GetByIdItemRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatetemRequest(ItemRequest ir)
        {
            throw new NotImplementedException();
        }
    }
}
