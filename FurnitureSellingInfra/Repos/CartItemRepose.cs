using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
            Log.Debug("start GetByIdCartItem_Repose");
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
                            Quantity = (int)o.Quantity,
                            ItemId = o.ItemId,

                        };
            Log.Information("return CartItem {CartItemId}", Id);

            Log.Debug("end GetByIdCartItem_Repose");

            return Query.FirstOrDefault();

        }


        public Task<List<UpdateCartItemDTO>> GetAllCartItem_Repose()
        {
            Log.Debug("start GetAllCartItem_Repose");

            var query = from q in _context.CartItems
                        select new UpdateCartItemDTO
                        {

                            CartItemId = q.CartItemId,
                            CartId = q.CartId,
                            ItemId = q.ItemId,
                            Quantity = (int)q.Quantity,
                        };
            Log.Information("return AllCartItem");
            Log.Debug("end AllCartItem_Repose");

            return query.ToListAsync();

        }
        public async Task CreateCartItem_Repose(CartItem model)
        {
            Log.Debug("start CreateCartItem_Repose");

            if (model != null)
            {
                // Add the new CartItem to the context
                _context.CartItems.Add(model);
                Log.Information("add new CartItem ", model.CartItemId);

                // Save changes to generate CartItemId if not already set
                await _context.SaveChangesAsync();

                var cartId = model.CartId;
                var cart = _context.Carts.FirstOrDefault(x => x.CartId == cartId);

                if (cart != null)
                {
                    var order = _context.Orders.FirstOrDefault(x => x.OrderId == cart.OrderId);

                    if (order != null)
                    {
                        order.TotalPrice = await CalculateTotalPrice(model.CartItemId);
                      
                        _context.Update(order);
                      await  _context.SaveChangesAsync();
                    }
                    else
                    {
                        Log.Error($"Order not found for CartId {cartId}");
                    }
                }
                else
                {
                    Log.Error($"Cart not found for CartItemId {model.CartItemId}");
                }
            }
            else
            {
                Log.Error("Model is null");
            }
        }


        public async Task UpdateCartItem_Repose(UpdateCartItemDTO dto)
        {
            Log.Debug("start  UpdateCartItem_Repose");
            var result = _context.CartItems.FirstOrDefault(x => x.CartItemId.Equals(dto.CartItemId));
            if (result != null)
            {

                //replacement 
                result.CartItemId = dto.CartItemId;
                result.Quantity = dto.Quantity;
                result.CartId = dto.CartId;
                result.ItemId = dto.ItemId;
                //update
                Log.Information("Update this CartItem", dto.CartItemId);
                _context.Update(result);
                await _context.SaveChangesAsync();
                var cart = _context.Carts.FirstOrDefault(x => x.CartId == result.CartId);
                var order = _context.Orders.FirstOrDefault(x => x.OrderId == cart.OrderId);
                if (order != null)
                {
                    order.TotalPrice = await  CalculateTotalPrice(result.CartItemId);
              
                    _context.Update(order);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Log.Error("cann't found this CartItem");
                    throw new Exception("can not found this CartItem");
                }
                Log.Debug("finished to  UpdateCartItem_Repose");
            }
        }

        public async Task DeleteCartItem_Repose(int Id)
        {
            Log.Debug("start  DeleteCartItem_Repose");

            var c = await _context.CartItems.FirstOrDefaultAsync(x => x.CartItemId == Id);
            if (c != null)
            {
                Log.Information("delete this CartItem", Id);
                _context.CartItems.Remove(c);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this CartItem");
                throw new Exception("can not found this CartItem");
            }

            Log.Debug("finished to  DeleteCartItem_Repose");
        }


        public async Task<float> CalculateTotalPrice(int Id)
        {
            Log.Debug("start to CalculateTotalPrice");

            var query = from ct in _context.CartItems
                        join c in _context.Carts on ct.CartId equals c.CartId
                        join i in _context.Items on ct.ItemId equals i.ItemId
                        join o in _context.Orders on c.OrderId equals o.OrderId
                        where ct.CartItemId == Id
                        select new
                        {
                            TotalPrice = (float)((i.Price * ct.Quantity) + o.Fee),
                        };


            return query.FirstOrDefault().TotalPrice;
        }

     
    }

}
