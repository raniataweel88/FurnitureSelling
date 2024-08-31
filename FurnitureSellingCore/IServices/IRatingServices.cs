using FurnitureSellingCore.DTO.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
   public interface  IRatingServices
    {
        public Task<CradRaviewDTO> GetByIdRating_Repose(int Id);
        public Task<List<CradRaviewDTO>> GetAllRating_Repose();
        public Task CreateRating_Repose(CreateRaviewDTO r);
        public Task UpdateRating_Repose(CradRaviewDTO dto);
        public Task DeleteRating_Repose(int id);
    }
}
