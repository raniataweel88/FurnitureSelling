using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
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
        public Task UpdateOrder(DetailsOrdertDTO dto, int? userType);
        public Task DeleteOrder(int id);
        public Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery();
        public Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto);
        public Task<List<DeliveryOrdertDTO>> SearchOrderforDelivery(string? adders);

    }
}
