using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.Order.Delivery;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IOrderRepos
    {   
        public Task<DetailsOrdertDTO> GetByIdOrder_Repose(int id);
        public Task<List<CardOrdertDTO>> GetAllOrder();
        public Task<int> CreateOrder_Repose(Order o);
        public Task UpdateOrder(DetailsOrdertDTO dto);
        public Task DeleteOrder(int id);
        public Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery();
        public Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto);
        public Task<List<DetalisDeliveryOrderDTO>> SearchOrderforDelivery(string? adders);
  


    }
}
