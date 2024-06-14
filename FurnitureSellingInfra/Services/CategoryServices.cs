using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepos _repose;
        public CategoryServices(ICategoryRepos repose)
        {
            _repose = repose;
        }
        public async Task<CardCategoryDTO> GetByIdCategory(int Id)
        {
            Log.Debug("start GetByIdCategory-Services", Id);
            return await _repose.GetByIdCategory_Repose(Id);
        }
        public async Task<List<CardCategoryDTO>> GetAllCategory()
        {
            Log.Debug("start GetAllCategory-Services");
           return await _repose.GetAllCategory_Repose();
         }

        public Task CreateCategory(CategoryDTO dto)
        {
            Log.Debug("start CreateCategory-Services");

            Category c = new Category
            {
                Title = dto.Title,
            };
            return _repose.CreateCategory_Repose(c);
        }
        public async Task UpdateCategory(CardCategoryDTO dto)
        {
            Log.Debug("start UpdateCategory-Services", dto.Id);
            await _repose.UpdateCategory_Repose(dto);
        }

        public async Task DeleteCategory(int Id)
        {
            Log.Debug("start DeleteCategory-Services", Id);
            await _repose.DeleteCategory_Repose(Id);
    }
  
    }
}
