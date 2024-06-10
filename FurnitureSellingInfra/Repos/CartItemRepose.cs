using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Item;
using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class CartItemRepose : ICartItemRepose
    {
        private readonly FurnitureSellingDbContext _context;
        public CartItemRepose(FurnitureSellingDbContext context)
        {
            _context = context;
        }  
     public async Task<CartItemDTO> GetByIdCartItem_Repose(int Id)
        {
            Log.Information("start GetByIdCartItem_Repose");
            var Query = from o in _context.CartItems
                        join i in _context.Items
                        on o.ItemId equals i.ItemId
                        join c in _context.Carts
                       on o.CartId equals c.CartId
                        where o.CartItemId.Equals(Id)
                        select new CartItemDTO
                        {
                            CartItemId = o.CartItemId,
                            CartId = o.CartId,
                            Name = i.Name,
                            Price = i.Price,
                            Image = i.Image,
                            Quantity =o.Quantity,
                            ItemId=o.ItemId,
                            
                          };
            return  Query.FirstOrDefault();
            Log.Information("end GetByIdCartItem_Repose");
    
        }
        

        public Task<List<CartItemDTO>> GetAllCartItem_Repose()
        {
            Log.Information("start GetAllCartItem_Repose");

            var query = from q in _context.CartItems
                        select new CartItemDTO
                        {
                            
                            CartItemId=q.CartItemId,
                            CartId = q.CartId,
                            ItemId = q.ItemId,
                            Quantity = q.Quantity,
                        };
            return query.ToListAsync();
            Log.Information("return AllCartItem_Repose");

        }
        public async Task CreateCartItem_Repose(CartItem model)
        {
            Log.Information("start  CreateCartItem_Repose");
            if (model != null)
            {
                Log.Information("CartItem not null");
                 _context.CartItems.Add(model);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("CartItem is empty");
                throw new Exception("CartItem is empty");
            }
            Log.Information("Finished to add  CartItem_Repose");
        }
        public async Task UpdateCartItem_Repose(CartItemDTO dto)
        {
            Log.Information("start  UpdateCartItem_Repose");
            var result = await _context.CartItems.FindAsync(dto.CartItemId);
            if (result != null)
            {
                Log.Information("found this CartItem");

                //replacement 
                result.CartItemId = dto.CartItemId;
                result.Quantity = dto.Quantity;
                result.CartId = dto.CartId;
                result.ItemId = dto.ItemId;
                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("cann't found this CartItem");
                throw new Exception("can not found this CartItem");
            }
            Log.Information("finished to  UpdateCartItem_Repose");
        }

        public async Task DeleteCartItem_Repose(int id)
        {
            Log.Information("start  DeleteCartItem_Repose");

            var c =_context.CartItems.FirstOrDefault(x => x.CartItemId == id);
            if (c != null)
            {
                Log.Information("found this CartItem");
                _context.CartItems.Remove(c);
                  await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this CartItem");
                throw new Exception("can not found this CartItem");
            }
         
            Log.Information("finished to  DeleteCartItem_Repose");
        }
        public async Task<float> CalculateTotalPrice(int CartId)
        {
            var query = from o in _context.Orders

                        join c in _context.Carts
                        on o.OrderId equals c.OrderId
                        join ct in _context.CartItems
                        on c.CartId equals ct.CartId
                        join i in _context.Items
                   on ct.ItemId equals i.ItemId
                        where c.CartId == CartId

                        select new
                        {

                            TotalPrice = (i.Price * ct.Quantity) + o.Fee,

                        };

            var Calculate = query.ToList();
            if (!Calculate.Any())
                throw new Exception("No cart items found for the given cart id");
            var totalCartPrice = Calculate.Sum(item => item.TotalPrice);


            return (float)totalCartPrice;

        }


    }
}
