using FurnitureSellingCore.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IOrderServices
    {
        public Task CreateOrder(CreateOrderDTO dto);
        public Task DeleteOrder(int id);
        public Task<DetailsOrdertDTO> GetByIdOrder(int id);
        public Task<CardOrdertDTO> GetAllOrder();
        public Task UpdateOrder(DetailsOrdertDTO dto);
    }
}
