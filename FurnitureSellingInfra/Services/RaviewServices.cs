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
    public class RaviewServices : IRaviewServices
    {
        private readonly IRaviewRepose _repose;
        public RaviewServices(IRaviewRepose repose) {
            _repose = repose;
        }


        public async Task<CradRaviewDTO> GetByIdRaview_Repose(int Id)
        {
            return await _repose.GetByIdRaview_Repose(Id);      }

        public async Task<List<CradRaviewDTO>> GetAllRaview_Repose(int ItemId)
        {
            return await _repose.GetAllRaview_Repose(ItemId);
        }
        public async Task CreateRaview_Repose(CreateRaviewDTO r)
        {

            Raview ra = new Raview()
            {
                ItemId = r.ItemId,
                RatingDate = r.RatingDate,
                RatingNumber = r.RatingNumber,
                Review = r.Review,
                UserId = r.UserId,
            };
       
            await _repose.CreateRaview_Repose(ra);
        }
        public async Task UpdateRaview_Repose(CradRaviewDTO dto)
        {
             await _repose.UpdateRaview_Repose(dto);
        }
        public async Task DeleteRaview_Repose(int Id)
        {
             await _repose.DeleteRaview_Repose(Id);
        }




    }
}
