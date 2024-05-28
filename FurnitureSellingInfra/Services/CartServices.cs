using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FurnitureSellingInfra.Services
{
    internal class CartServices : ICartServices
    {
        public Task CreateCart(CartDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCart(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CartDTO> GetAllCart()
        {
            throw new NotImplementedException();
        }

        public Task<CartDTO> GetByIdCart(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCart(CartDTO dto)
        {
            throw new NotImplementedException();
        }
    }


}
