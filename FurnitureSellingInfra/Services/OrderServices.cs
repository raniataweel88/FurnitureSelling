using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace FurnitureSellingInfra.Services
{
    public class OrderServices : IOrderServices
    {
        int r = 0;
        private readonly IOrderRepos _repose;
        public OrderServices(IOrderRepos repose)
        {
            _repose = repose;
        }
        public async Task<DetailsOrdertDTO> GetByIdOrder(int id)
        {
            return await _repose.GetByIdOrder_Repose(id);
        }
        public async Task<List<CardOrdertDTO>> GetAllOrder()
        {
            return await _repose.GetAllOrder();
        }

        public async Task CreateOrder(CreateOrderDTO dto)
        {
            Order o = new Order
            {
                CustomerNote = dto.CustomerNote,
                Title = dto.Title,
                Date = dto.Date,
            };

            r = await _repose.CreateOrder_Repose(o);

        }


        public async Task UpdateOrder(DetailsOrdertDTO dto, int? userType)
        {

            await _repose.UpdateOrder(dto, userType);
        }
        public async Task DeleteOrder(int id)
        {
            await _repose.DeleteOrder(id);
        }


        public async Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery()
        {
            return await _repose.GetAllOrderforDelivery();
        }

        public async Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto)
        {
            await _repose.UpdateOrderforDelivery(dto);
        }

        public async Task<List<DeliveryOrdertDTO>> SearchOrderforDelivery(string? adders)
        {
            return await _repose.SearchOrderforDelivery(adders);
        }


    }
}
