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
                            Id = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            CustomerNote = o.CustomerNote,
                            Date = o.Date,
                            Fee = o.Fee,
                            Title = o.Title,
                            

                        };
            return await Query.FirstOrDefaultAsync();
            Log.Debug("finished to  GetByIdOrder_Repose");

        }
        public async Task<List<CardOrdertDTO>> GetAllOrder()
        {
            Log.Debug("start to  GetAllOrder_Repose");

            var Query = from o in _context.Orders
                        select new CardOrdertDTO
                        {
                            Id = o.OrderId,
                            Date = o.Date,
                            Title = o.Title,
                            TotalPrice = o.TotalPrice,
                            
                        };

            return Query.ToList();
            Log.Debug("finished to  GetAllOrder_Repose");

        }
        public async Task<int> CreateOrder_Repose(Order o)
        {
            Log.Debug("start to  CreateOrder_Repose");
            if (o != null)
            {
                await _context.Orders.AddAsync(o);
                await _context.SaveChangesAsync();
                Log.Information("add Order");

                return o.OrderId;

            }
            else
            {
                Log.Error("the Order is empty");
                throw new Exception("the Order is empty");
            }
            Log.Information("finished to  CreateOrder_Repose");
        }
        public async Task UpdateOrder(DetailsOrdertDTO dto)
        {
            var o = await _context.Orders.FindAsync(dto.Id);

            Log.Debug("start to  UpdateOrder _Repose");

            if (o != null)
            {

           
                    o.OrderId = dto.Id;
                    o.Title = dto.Title;
                    o.Date = dto.Date;
                    o.CustomerNote = dto.CustomerNote;
                    o.Fee = dto.Fee;
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
            if (o != null)
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



        public async Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery()
        {
            Log.Debug("start to  GetAllOrderforDelivery");

            var Query = from o in _context.Orders
                        select new DeliveryOrdertDTO
                        {

                            Title = o.Title,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = (bool)o.StatusDelivery,
                            Id = o.OrderId,

                        };

            return Query.ToList();
            Log.Debug("finished to  GetAllOrderforDelivery");
        }

        public async Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto)
        {
            var o = await _context.Orders.FindAsync(dto.Id);

            Log.Debug("start to  UpdateOrderforDelivery");

            if (o != null)
            {

                o.OrderId = dto.Id;
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
                        join u in _context.Users
                        on o.UserId equals u.UserId
                        where u.Address.Contains(adders)
                        select new DetalisDeliveryOrderDTO
                        {
                            
                            Id = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = (bool)o.StatusDelivery,
                            Title = o.Title,
                            Phone = u.Phone,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address,
                            DeliveryNote=o.DeliveryNote,
                            RecivingDate= (DateTime)o.RecivingDate
                            
                        };
            return Query.ToList();
            Log.Debug("end  to  search Order forDelivery");

        }

        #endregion

    }
    }

