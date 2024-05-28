using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FurnitureSellingCore.IRepos
{
    public interface ICartItemRepose
    {
        public Task CreateCartItem_Repose(CartItem model);
        public Task UpdateCartItem_Repose(CartItem dto);
        
        public Task<CartItem> GetByIdCartItem_Repose(int Id);
        public Task<List<CartItem>> GetAllCartItem_Repose();
    }

 
}
