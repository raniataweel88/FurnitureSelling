using FurnitureSellingCore.DTO.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public  interface ICartServices
    {
        public Task CreateCart(CartDTO dto);

        public Task<CartDTO> GetByIdCart(int Id);
        public Task<CartDTO> GetAllCart();
        public Task UpdateCart(CartDTO dto);
        public Task DeleteCart(int Id);
    }
}
