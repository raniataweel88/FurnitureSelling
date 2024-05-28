using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class ItemRepos : IItemRepos
    {
        public Task CreateItem_Repose(Item ct)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAllItem_Repose()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetByIdItem_Repose(int id)
        {
            throw new NotImplementedException();
        }

        public Task Updatetem(Item ct)
        {
            throw new NotImplementedException();
        }
    }
}
