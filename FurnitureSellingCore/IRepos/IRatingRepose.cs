using FurnitureSellingCore.DTO.CartItem;
using FurnitureSellingCore.DTO.Rating;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IRatingRepose
    {
        public Task<CradRaviewDTO> GetByIdRating_Repose(int Id);
        public Task<List<CradRaviewDTO>> GetAllRating_Repose();
        public Task CreateRating_Repose(Raview r);
        public Task UpdateRating_Repose(CradRaviewDTO dto);
        public Task DeleteRating_Repose(int id);
    }
}
