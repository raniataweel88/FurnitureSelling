using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public  interface ICartServices
    {      
        public Task<CardCartDTO> GetByIdCart(int Id);
        public Task<List<Cart>> GetAllCart();
        public Task CreateCart(CartDTO dto);
        public Task UpdateCart(Cart dto);
        public Task DeleteCart(int Id);
    }
}
