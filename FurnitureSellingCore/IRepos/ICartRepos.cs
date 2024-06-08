
using FurnitureSellingCore.DTO.Cart;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface ICartRepos
    {
        public Task<CardCartDTO> GetByIdCart_Repose(int Id);
        public Task<List<CardCartDTO>> GetAllCart_Repose();
        public Task CreateCart_Repose(Cart c);  
        public Task UpdateCart_Repose(CardCartDTO c);
        public Task DeleteCart_Repose(int Id);

    }
}
