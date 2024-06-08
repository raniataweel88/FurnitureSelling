using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Order;
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
        public async  Task<DetailsOrdertDTO> GetByIdOrder_Repose(int id)
        {
            Log.Information("start to  GetByIdOrder_Repose");

            var Query = from o in _context.Orders
                        where o.OrderId == id
                        select new DetailsOrdertDTO
                        {  Id=o.OrderId,
                            TotalPrice = (float)o.TotalPrice,
                            CustomerNote = o.CustomerNote,
                            Date = (DateTime)o.Date,
                            Fee = (float)o.Fee,
                            Title = o.Title,
                          
                        };
            return  Query.FirstOrDefault();
            Log.Information("finished to  GetByIdOrder_Repose");

        }
        public async Task<List<CardOrdertDTO>> GetAllOrder()
        {
            Log.Information("start to  GetAllOrder_Repose");

            var Query = from o in _context.Orders
                        select new CardOrdertDTO
                        {
                            Id = o.OrderId,
                            Date = (DateTime)o.Date,
                            Title = o.Title,
                            TotalPrice = (float)o.TotalPrice,
                        };

            return Query.ToList();
            Log.Information("finished to  GetAllOrder_Repose");

        }
        public async  Task CreateOrder_Repose(Order o)
        {
            Log.Information("start to  CreateOrder_Repose");
            if (o != null)
            {
                Log.Information("the Order not null");


                await _context.Orders.AddAsync(o);
                
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("the Order is empty");
                throw new Exception("the Order is empty");
            }
            Log.Information("finished to  CreateOrder_Repose");
        }
        public async Task UpdateOrder(DetailsOrdertDTO dto, int? userType)
        {
            var o = await _context.Orders.FindAsync(dto.Id);

            Log.Information("start to  UpdateOrder _Repose");

            if (o != null)
            {

                if (userType == 2)
                {
                    o.OrderId = dto.Id;
               //     o.StatusDelivery = dto.StatusDelivery;
                    _context.Update(o);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    o.OrderId = dto.Id;
                    o.Title = dto.Title;
                    o.Date = dto.Date;
                    o.CustomerNote = dto.CustomerNote;
                    o.Fee = dto.Fee;
                    _context.Update(o);
                    await _context.SaveChangesAsync();
                } 

            }
    
            else
            {
                Log.Error("can not found this Orders");
                throw new Exception("can not found this Orders");
            }
            Log.Information("finished to  UpdateOrder_Repose");

        }

        public async Task DeleteOrder(int id)
        {
            var o = _context.Orders.FirstOrDefault(x => x.OrderId == id);
        
            Log.Information("start to  DeleteOrder_Repose");
            if (o != null)
            {
                Log.Information("found this Orders");
                _context.Orders.Remove(o);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this Orders");
                throw new Exception("can not found this Orders");
            }
            Log.Information("Finished to DeleteOrder_Repose");
        }



        #endregion
        #region Order delivery

        public async Task<DeliveryOrdertDTO> GetByIdOrder_ReposeforDelivery(int id)
        {
            Log.Information("start to  GetByIdOrder_ReposeforDelivery");

            var Query = from o in _context.Orders
                        join u in _context.Users
                        on o.UserId equals u.UserId
                        where o.OrderId == id
                        select new DeliveryOrdertDTO
                        {
                            Id = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = o.StatusDelivery,
                            Title = o.Title,
                            Phone = u.Phone,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address
                        };
            return Query.FirstOrDefault();
            Log.Information("finished to  GetByIdOrder_Repose");
        }

        public async Task<List<DeliveryOrdertDTO>> GetAllOrderforDelivery()
        {
            Log.Information("start to  GetAllOrderforDelivery");

            var Query = from o in _context.Orders
                        select new DeliveryOrdertDTO
                        {
                           
                            Title = o.Title,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery=o.StatusDelivery,
                            Id=o.OrderId,

                        };

            return Query.ToList();
            Log.Information("finished to  GetAllOrderforDelivery");
        }

        public async Task UpdateOrderforDelivery(DeliveryOrder_updatetDTO dto)
        {
            var o = await _context.Orders.FindAsync(dto.Id);

            Log.Information("start to  UpdateOrderforDelivery");

            if (o != null)
            {

                    o.OrderId = dto.Id;
                  o.StatusDelivery=dto.StatusDelivery;
               
                    _context.Update(o);
                    await _context.SaveChangesAsync();
                
            }

            else
            {
                Log.Error("can not found this Orders");
                throw new Exception("can not found this Orders");
            }
            Log.Information("finished to  UpdateOrderforDelivery");

        }

      

        public async Task<List<DeliveryOrdertDTO>> SearchOrderforDelivery(string? adders)
        {
            var Query = from o in _context.Orders
                        join u in _context.Users
                        on o.UserId equals u.UserId
                        where u.Address ==adders
                        select new DeliveryOrdertDTO
                        {
                            Id = o.OrderId,
                            TotalPrice = o.TotalPrice,
                            StatusDelivery = o.StatusDelivery,
                            Title = o.Title,
                            Phone = u.Phone,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Address = u.Address
                        };
            return Query.ToList();
        }
    }
        #endregion
    }

