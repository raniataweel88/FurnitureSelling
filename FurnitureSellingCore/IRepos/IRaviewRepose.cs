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
    public interface IRaviewRepose
    {
        public Task<CradRaviewDTO> GetByIdRaview_Repose(int Id);
        public Task<List<CradRaviewDTO>> GetAllRaview_Repose(int ItemId);
        public Task CreateRaview_Repose(Raview r);
        public Task UpdateRaview_Repose(CradRaviewDTO dto);
        public Task DeleteRaview_Repose(int id);
    }
}
