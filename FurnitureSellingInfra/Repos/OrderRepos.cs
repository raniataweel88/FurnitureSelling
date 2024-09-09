using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.DTO.Order.Delivery;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FurnitureSellingInfra.Repos
{
    public class OrderRepos : IOrderRepos
    {
        private readonly FurnitureSellingDbContext _context;
        private readonly ICartRepos _cartRepos;
        public OrderRepos(FurnitureSellingDbContext context, ICartRepos cartRepos)
        {
            _context = context;
            _cartRepos = cartRepos;
        }
        #region Oreder

        public async Task<DetailsOrdertDTO> GetByIdOrder_Repose(int Id)
        {
            Log.Debug("start to  GetByIdOrder_Repose");

            var Query = from o in _context.Orders
  
                        where o.OrderId == Id
                        select new DetailsOrdertDTO
                        {
                            OrderId = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            CustomerNote = o.CustomerNote,
                            Date = o.Date,
                            Fee = o.Fee,
                            Title = o.Title,
                            statusDelivery=o.StatusDelivery,
                           Preparingrequest=o.Preparingrequest,
                           
                            Paymentmethod = (int)o.Paymentmethod,

                        };
            var reslt = await Query.FirstOrDefaultAsync();

            if (reslt.Paymentmethod == 0)
            {
                return reslt;
                throw new Exception(" You are required to receive money from a customer");

            }
            else
            {
                return reslt;
                throw new Exception("the money is received");
            }
            Log.Debug("finished to  GetByIdOrder_Repose");


        }
      
        public async Task<List<CardOrdertDTO>> GetAllOrder()
        {
            Log.Debug("start to  GetAllOrder_Repose");

            var Query = from o in _context.Orders
                        select new CardOrdertDTO
                        {
                            OrderId = o.OrderId,
                            Date = o.Date,
                            Title = o.Title,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = o.StatusDelivery,
                            Preparingrequest=o.Preparingrequest,
                        };
            Log.Debug("finished to  GetAllOrder_Repose");
            return Query.ToList();
        }
        public async Task<int> CreateOrder_Repose(Order o)
        {
            Log.Debug("start to  CreateOrder_Repose");
            if (o != null)
            {
                await _context.Orders.AddAsync(o);
                await _context.SaveChangesAsync();
                Log.Information("add Order");
                Log.Debug("finished to  CreateOrder_Repose");
                return o.OrderId;
            }

            else
            {
                Log.Error("the Order is empty");
                throw new Exception("the Order is empty");
            }
        }
        public async Task UpdateOrder(DetailsOrdertDTO dto)
        {
            var o = await _context.Orders.FindAsync(dto.OrderId);

            Log.Debug("start to  UpdateOrder _Repose");

            if (o != null) { 
                o.Preparingrequest = dto.Preparingrequest;
                o.OrderId = dto.OrderId;
      


                _context.Update(o);
                await _context.SaveChangesAsync();
                Log.Information("Update this Orders");
            }
            else
            {
                Log.Error("can not found this Orders");
                throw new Exception("can not found this Orders");
            }
            Log.Debug("finished to  UpdateOrder_Repose");

        }

        public async Task DeleteOrder(int Id)
        {
            var o = _context.Orders.FirstOrDefault(x => x.OrderId == Id);

            Log.Debug("start to  DeleteOrder_Repose");
            if (o != null&&o.Preparingrequest==false)
            {
                _context.Remove(o);
                await _context.SaveChangesAsync();
                Log.Information("delete this Orders");
            }
            else
            {
                Log.Error("can not found this Orders");
                throw new Exception("can not found this Orders");
            }
            Log.Debug("Finished to DeleteOrder_Repose");
        }

        #endregion
        #region Order delivery
        public async Task<DetalisDeliveryOrderDTO> GetByIdOrder_Delivary(int Id)
        {
            Log.Debug("start to  GetByIdOrder_Repose");
            var Query = from o in _context.Orders
                        
                        where o.OrderId == Id
                        join c in _context.Carts
                        on o.OrderId equals c.OrderId
                        join user in _context.Users
                      on c.UserId equals user.UserId

                        select new DetalisDeliveryOrderDTO
                        {
                            Preparingrequest=o.Preparingrequest,
                            OrderId = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            Title = o.Title,
                            Paymentmethod = (int)o.Paymentmethod,
                            Address = user.Address,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            StatusDelivery = (bool)o.StatusDelivery,
                            Phone = user.Phone,
                            RecivingDate = o.RecivingDate,
                        };
            var reslt = await Query.FirstOrDefaultAsync();

            if (reslt.Paymentmethod == 0)
            {
                return reslt;
                throw new Exception(" You are required to receive money from a customer");

            }
            else
            {
                return reslt;
                throw new Exception("the money is received");
            }
            Log.Debug("finished to  GetByIdOrder_Repose");


        }
        public async Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery()
        {
            Log.Debug("start to  GetAllOrderforDelivery");

            var Query = from o in _context.Orders
                        where o.Preparingrequest==true
                        select new DeliveryOrdertDTO
                        {
                            Preparingrequest= o.Preparingrequest,
                            Title = o.Title,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = (bool)o.StatusDelivery,
                            Id = o.OrderId,

                        };
            Log.Debug("finished to  GetAllOrderforDelivery");
            return Query.ToList();
        }

        public async Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto)
        {
            var o = await _context.Orders.FindAsync(dto.OrderId);

            Log.Debug("start to  UpdateOrderforDelivery");

            if (o != null)
            {

                o.OrderId = dto.OrderId;
                o.StatusDelivery = dto.StatusDelivery;
                _context.Update(o);
                await _context.SaveChangesAsync();
                Log.Information("Update this Order form Delivery");
            }

            else
            {
                Log.Error("can not found this Orders");
                throw new Exception("can not found this Orders");
            }
            Log.Debug("finished to  Update Order forDelivery");

        }



        public async Task<List<DetalisDeliveryOrderDTO>> SearchOrderforDelivery(string? adders)
        {
            Log.Debug("start  to  search Order forDelivery");


            var Query = from o in _context.Orders
                        join c in _context.Carts
                        on o.OrderId equals c.OrderId
                        join u in _context.Users
                        on c.UserId equals u.UserId
                        where u.Address.Contains(adders)
                        &&  o.Preparingrequest == true
                        select new DetalisDeliveryOrderDTO
                        {
                            OrderId = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = (bool)o.StatusDelivery,
                            Title = o.Title,
                            Phone = u.Phone,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address,
                            DeliveryNote = o.DeliveryNote,
                            RecivingDate = (DateTime)o.RecivingDate,
                            Paymentmethod = (int)o.Paymentmethod,

                        };
     
            Log.Debug("end  to  search Order forDelivery");
            return Query.ToList();
        }

        public async Task<Payment> IsvaildPayment(string code, string cardNumber, string cardHolder, float price)
        {
            var payments = await _context.Payments.FirstOrDefaultAsync(x => x.Blane >= price && x.Code == code && x.CardNumber == cardNumber &&
            x.CardHolder == cardHolder);

            return  payments;


            #endregion
        }

        public async Task UpdatePayment(Payment p)
        {
            _context.Update(p);
           await _context.SaveChangesAsync(); 
        }

        public async Task<List<CardOrdertDTO>> GetAllOrderForUser(int userId)
        {
            Log.Debug("start to  GetAllOrder_Repose");

            var Query = from o in _context.Orders
                        join c in _context.Carts
                       on o.OrderId equals c.OrderId
                        join u in _context.Users
                        on c.UserId equals u.UserId
                        where c.UserId == userId
                        select new CardOrdertDTO
                        {
                            OrderId = o.OrderId,
                            Date = o.Date,
                            Title = o.Title,

                            TotalPrice = o.TotalPrice,

                        };
            Log.Debug("finished to  GetAllOrder_Repose");
            return Query.ToList();
        }
    }
    }

