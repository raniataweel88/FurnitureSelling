using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using K4os.Hash.xxHash;
using Microsoft.EntityFrameworkCore;
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
            Log.Information("start  GetByIdCart_Repose");

            var Qery = from c in _context.Carts.
                       Where(x => x.CartId == Id)
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
                           IsActiveId = c.IsActiveId,
                           CartId = Id,
                           UserId = c.UserId,
                           Name = u.FirstName + u.LastName,
                           Email = u.Email,

                       };
            return Qery.FirstOrDefault();
            Log.Information("finished to  Get ByIdCart_Repose");
        }
        public async Task<List<CardCartDTO>> GetAllCart_Repose()
        {
            Log.Information("start to  GetAllCart_Repose");
            var Qery = from c in _context.Carts
                       join u in _context.Users
                       on c.UserId equals u.UserId
                       join o in _context.Orders
                      on c.OrderId equals o.OrderId
                       select new CardCartDTO
                       {
                           CartId = c.CartId,
                           OrderId = c.OrderId,
                           UserId = c.UserId,
                           IsActiveId = c.IsActiveId,
                           Email = u.Email,
                           Name = u.FirstName + u.LastName,
                           Title = o.Title,
                           TotalPrice = o.TotalPrice,

                       };
            return Qery.ToList();
            Log.Information("finished to  GetAllCart_Repose");

        }

        public async Task CreateCart_Repose(Cart c)
        {
            Log.Information("start to  CreateCart_Repose");
            if (c != null)
            {
                Log.Information("the cart ready to create");
                await _context.Carts.AddAsync(c);
                await _context.SaveChangesAsync();
                var o = _context.Orders.FirstOrDefault(x => x.OrderId == c.OrderId);
                o.UserId = c.UserId;
                o.TotalPrice = await CalculateTotalPrice(c.CartId);
                _context.Update(o);
                await _context.SaveChangesAsync();


            }
            else
            {
                Log.Error("the cart is empty");
                throw new Exception("the cart is empty");
            }

            Log.Information("finished to  CreateCart_Repose");

        }
        public async Task UpdateCart_Repose(CardCartDTO c)
        {
            Log.Information("start to  UpdateCart_Repose");
            var r = await _context.Carts.FindAsync(c.CartId);
            if (r != null)
            {
                Log.Information("found this Cart");
                //replacement 
                r.CartId = c.CartId;
                r.OrderId = c.OrderId;
                r.UserId = c.UserId;

                _context.Update(r);
                //save changes 
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this cat");
                throw new Exception("can not found this cat");
            }
            Log.Information("finished to  UpdateCart_Repose");
        }
        public async Task DeleteCart_Repose(int Id)
        {
            Log.Information("start to  DeleteCart_Repose");
            var c = _context.Carts.FirstOrDefault(x => x.CartId == Id);
            if (c != null)
            {
                Log.Information("found this cart");
                _context.Carts.Remove(c);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this cat");
                throw new Exception("can not found this cat");
            }
            Log.Information("Finished to DeleteCart_Repose");
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
