using FurnitureSellingCore.DTO.Rating;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using FurnitureSellingInfra.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    public class RaviewServices : IRatingServices
    {
        private readonly IRatingRepose _repose;
        public RaviewServices(IRatingRepose repose) {
            _repose = repose;
        }


        public async Task<CradRaviewDTO> GetByIdRating_Repose(int Id)
        {
            return await _repose.GetByIdRating_Repose(Id);      }

        public async Task<List<CradRaviewDTO>> GetAllRating_Repose()
        {
            return await _repose.GetAllRating_Repose();
        }
        public async Task CreateRating_Repose(CreateRaviewDTO r)
        {

            Raview ra = new Raview()
            {
                ItemId = r.ItemId,
                RatingDate = r.RatingDate,
                RatingNumber = r.RatingNumber,
                Review = r.Review,
                UserId = r.UserId,
            };
       
            await _repose.CreateRating_Repose(ra);
        }
        public async Task UpdateRating_Repose(CradRaviewDTO dto)
        {
             await _repose.UpdateRating_Repose(dto);
        }
        public async Task DeleteRating_Repose(int Id)
        {
             await _repose.DeleteRating_Repose(Id);
        }




    }
}
