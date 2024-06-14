using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.Order.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IOrderServices
    { 
        public Task<DetailsOrdertDTO> GetByIdOrder(int id);
        public Task<List<CardOrdertDTO>> GetAllOrder();
        public Task CreateOrder(CreateOrderDTO dto);
     
        public Task UpdateOrder(DetailsOrdertDTO dto); 
        public Task DeleteOrder(int id);
        public Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery();
        public Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto);
        public Task<List<DetalisDeliveryOrderDTO>> SearchOrderforDelivery(string? adders);
     


    }
}
