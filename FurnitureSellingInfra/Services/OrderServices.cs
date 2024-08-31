using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.Order.Delivery;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Org.BouncyCastle.Asn1.X509;
using Serilog;
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
        private readonly IOrderRepos _repose;
        public OrderServices(IOrderRepos repose)
        {
            _repose = repose;
        }
        public async Task<DetailsOrdertDTO> GetByIdOrder(int Id)
        {
            Log.Debug("start GetByIdOrder-Services", Id);
            return await _repose.GetByIdOrder_Repose(Id);
        }
        public async Task<List<CardOrdertDTO>> GetAllOrder()
        {
            Log.Debug("start GetAllOrder-Services");
            return await _repose.GetAllOrder();
        }

        public async Task<int> CreateOrder(CreateOrderDTO dto)
        {
            Log.Debug("start CreateOrder-Services");
            Order o = new Order
            {
                CustomerNote = dto.CustomerNote,
                Title = dto.Title,
                Date = dto.Date,
                Paymentmethod= (FurnitureSellingCore.helper.Enums.Paymentmethod)dto.Paymentmethod,
            };

          return  await _repose.CreateOrder_Repose(o);
        }


        public async Task UpdateOrder(DetailsOrdertDTO dto)
        {
            Log.Debug("start UpdateOrder-Services", dto.Id);
            await _repose.UpdateOrder(dto);
        }
        public async Task DeleteOrder(int Id)
        {
            Log.Debug("start DeleteOrder-Services", Id);

            await _repose.DeleteOrder(Id);
        }


        public async Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery()
        {
            Log.Debug("start GetAllOrderforDelivery-Services");
            return await _repose.GetAllOrderforDelivery();
        }

        public async Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto)
        {
            Log.Debug("start UpdateOrderforDelivery-Services");
            await _repose.UpdateOrderforDelivery(dto);
        }

        public async Task<List<DetalisDeliveryOrderDTO>> SearchOrderforDelivery(string? adders)
        {
            Log.Debug("start SearchOrderforDelivery-Services");
            return await _repose.SearchOrderforDelivery(adders);
        }

        public async Task PaymentMethod(CreateOrderDTO dto ,int Id)
        {
            var order = await _repose.GetByIdOrder_Repose(Id);
            if (order.Paymentmethod == 1)
            {
              var payment = await _repose.IsvaildPayment(dto.Code, dto.CardNumber, dto.CardHolder, (float)order.TotalPrice);
                if (payment != null)
                {
                    payment.Blane -= order.TotalPrice;
                    await _repose.UpdatePayment(payment);
                    Order o = new Order
                    {
                        CustomerNote = dto.CustomerNote,
                        Title = dto.Title,
                        Date = dto.Date,
                    };

                    await _repose.CreateOrder_Repose(o);
                }
                else
                    throw new Exception(" You are required to receive money from a customer");
            }
           

        
            else
            {
                throw new Exception("Invalide Payment");
            }
        }

        public async Task<List<CardOrdertDTO>> GetAllOrderForUser(int userId)
        {
            Log.Debug("start GetAllOrder-Services");
            return await _repose.GetAllOrderForUser(userId);
        }

        public async Task<DetalisDeliveryOrderDTO> GetByIdOrder_Delivary(int Id)
        {

            Log.Debug("start GetAllOrder-Services");
            return await _repose.GetByIdOrder_Delivary(Id);
        }
    }
}
