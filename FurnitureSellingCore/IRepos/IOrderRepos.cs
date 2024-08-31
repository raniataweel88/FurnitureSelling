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
        public Task<List<CardOrdertDTO>> GetAllOrderForUser(int userId);

        public Task<List<CardOrdertDTO>> GetAllOrder();
        public Task<int> CreateOrder_Repose(Order order);
        public Task UpdateOrder(DetailsOrdertDTO dto);
        public Task UpdatePayment(Payment p);

        public Task DeleteOrder(int id);
        public Task<DetalisDeliveryOrderDTO> GetByIdOrder_Delivary(int Id);

        public Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery();
        public Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto);
        public Task<List<DetalisDeliveryOrderDTO>> SearchOrderforDelivery(string? adders);

        public Task<Payment> IsvaildPayment(string code, string cardNumber, string cardHolder, float price);
  


    }
}
