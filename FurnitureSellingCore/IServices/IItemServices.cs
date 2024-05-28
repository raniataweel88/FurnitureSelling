using FurnitureSellingCore.DTO.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IItemServices

    {

        public Task CreateItemServices(CreateItemDTO dto);
        public Task DeleteItem(int id);
        public Task<DetailsItemDTO> GetByIdItem(int id);
        public Task<CardItemDTO> GetAllItem();
        public Task Updateitem(DetailsItemDTO dto);

    }
}
