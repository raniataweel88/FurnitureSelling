using FurnitureSellingCore.DTO.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
   public interface  IRaviewServices
    {
        public Task<CradRaviewDTO> GetByIdRaview_Repose(int Id);
        public Task<List<CradRaviewDTO>> GetAllRaview_Repose(int ItemId);
        public Task CreateRaview_Repose(CreateRaviewDTO r);
        public Task UpdateRaview_Repose(CradRaviewDTO dto);
        public Task DeleteRaview_Repose(int id);
    }
}
