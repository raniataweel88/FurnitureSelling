using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class CartItemRepose : ICartItemRepose
    {
        public Task CreateCartItem_Repose(CartItem model)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItem>> GetAllCartItem_Repose()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetByIdCartItem_Repose(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartItem_Repose(CartItem dto)
        {
            throw new NotImplementedException();
        }

       
    }
}
