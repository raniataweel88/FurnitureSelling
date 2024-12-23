﻿using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using K4os.Hash.xxHash;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Crmf;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class CartRepos : ICartRepos
    {
        private readonly FurnitureSellingDbContext _context;

        public CartRepos(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        public async Task<CardCartDTO> GetByIdCart_Repose(int Id)
        {
            Log.Debug("start GetByIdCart_Repose");

            var query = from c in _context.Carts
                        .Where(x => x.CartId == Id)
                        join o in _context.Orders
                        on c.OrderId equals o.OrderId
                        join u in _context.Users
                        on c.UserId equals u.UserId
                        select new CardCartDTO
                        {
                            OrderId = c.OrderId,
                            TotalPrice = o.TotalPrice,
                            Title = o.Title,
                            Fee = o.Fee,
                            IsActiveId = (bool)c.IsActiveId,
                            CartId = Id,
                            UserId = c.UserId,
                          
                        };

            Log.Information("Retrieved cart with Id {CartId}", Id);
            Log.Debug("Finished GetByIdCart_Repose");

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Cart>> GetAllCart_Repose(int UserId)
        {
            Log.Debug("start to  GetAllCart_Repose");
            var Qery = from c in _context.Carts
                       join u in _context.Users
                       on c.UserId equals u.UserId
                       where c.UserId == UserId
                       && c.IsActiveId==true
                       select new Cart
                       {
                           IsActiveId=c.IsActiveId,
                           CartId = c.CartId,
                           OrderId = c.OrderId,
                           UserId = c.UserId,
                       };
            Log.Information("get all cart");
            Log.Debug("finished to  GetAllCart_Repose");

            return Qery.ToList();

        }
        public async Task<List<Cart>> GetAllCart_ReposeReviw(int orderTd)
        {
            Log.Debug("start to  GetAllCart_Repose");
            var Qery = from c in _context.Carts
                     where c.OrderId == orderTd
                    && c.IsActiveId==false
                       select new Cart
                       {
                           IsActiveId = c.IsActiveId,
                           CartId = c.CartId,
                           OrderId = c.OrderId,
                           UserId = c.UserId,
                       };
            Log.Information("get all cart");
            Log.Debug("finished to  GetAllCart_Repose");

            return Qery.ToList();

        }

        public async Task<int> CreateCart_Repose(Cart c)
    
            {
                Log.Debug("start to  CreateCart_Repose");

            var existingCart = await _context.Carts
                  .Where(x => x.UserId == c.UserId)
                  .OrderByDescending(x => x.CartId) 
                  .FirstOrDefaultAsync();

            if (existingCart != null)
                {
                
                    if (existingCart.IsActiveId==true)
                    {
                        return existingCart.CartId;
                    }
               
                    else
                    {
                     Cart cart = new Cart();
                    cart.IsActiveId = true;
                    cart.UserId = c.UserId;
                     cart.OrderId = c.OrderId;
                    await _context.Carts.AddAsync(cart);
                    await _context.SaveChangesAsync();
                    return cart.CartId;
                    }
                
                    
                }
                else
                {
                  Log.Information("Adding new cart for user", c.CartId);
                c.IsActiveId = true;
                await    _context.Carts.AddAsync(c);
                await _context.SaveChangesAsync();
                return c.CartId; 
                Log.Debug("finished CreateCart_Repose");
                }

            
            }

            public async Task UpdateCart_Repose(CardCartDTO c)
        {
            Log.Debug("start to  UpdateCart_Repose");
            var r = await _context.Carts.FindAsync(c.CartId);
            if (r != null)
            {
                r.CartId = c.CartId;
                r.OrderId = c.OrderId;
                r.UserId = c.UserId;
                r.IsActiveId = c.IsActiveId;

                _context.Update(r);
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == c.OrderId);
                var cartiem = await _context.CartItems.FirstOrDefaultAsync(x => x.CartId == c.CartId);

                var items =await _context.Items.Where(x => x.ItemId == cartiem.ItemId).ToListAsync();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        item.RestQuantity = (int)(item.Quantity - cartiem.Quantity);
                        _context.Update(item);
                    }

                    await _context.SaveChangesAsync();
                }

                if (order != null)
                {
                    order.TotalPrice = await CalculateTotalPrice(cartiem.CartItemId);

                    _context.Update(order);
                    await _context.SaveChangesAsync();

                }
                Log.Information("update this Cart",c.CartId);
                //save changes 
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this cat");
                throw new Exception("can not found this cat");
            }
            Log.Debug("finished to  UpdateCart_Repose");
        }
        public async Task DeleteCart_Repose(int Id)
        {
            Log.Debug("start to  DeleteCart_Repose");
            var c = _context.Carts.FirstOrDefault(x => x.CartId == Id);
            if (c != null)
            {
                c.IsActiveId = false;
                _context.Update(c);

                Log.Information("delete this cart", c.CartId);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this cat");
                throw new Exception("can not found this cat");
            }
            Log.Debug("Finished to DeleteCart_Repose");
        }
    public async Task<float> CalculateTotalPrice(int Id)
    {
        Log.Debug("Start to CalculateTotalPrice");

        var ct = _context.CartItems.FirstOrDefault(x => x.CartItemId == Id);
        var c = _context.Carts.FirstOrDefault(x => x.CartId == ct.CartId);
        var o = _context.Orders.FirstOrDefault(x => x.OrderId == c.OrderId);
        var i = _context.Items.FirstOrDefault(x => x.ItemId == ct.ItemId);
        float or;
        if (o.Fee == null)
            or = (float)((i.Price * ct.Quantity) + 0);
        else
            or = (float)((i.Price * ct.Quantity) + o.Fee);
        return or;
    }

}
}
