using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class ItemServices : IItemServices
    {
        public Task CreateItemServices(CreateItemDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CardItemDTO> GetAllItem()
        {
            throw new NotImplementedException();
        }

        public Task<DetailsItemDTO> GetByIdItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task Updateitem(DetailsItemDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
