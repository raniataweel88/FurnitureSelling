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
        public Task CreateItem_Repose(Item ct);

        public Task<Item> GetByIdItem_Repose(int id);
        public Task<List<Item>> GetAllItem_Repose();
        public Task Updatetem(Item ct);



    }
}
