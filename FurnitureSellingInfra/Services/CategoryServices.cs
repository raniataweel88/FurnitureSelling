using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
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
        public async Task<CardCategoryDTO> GetByIdCategory(int id)
        {
            return await _repose.GetByIdCategory_Repose(id); }
        public async Task<List<CardCategoryDTO>> GetAllCategory()
        {
            return await _repose.GetAllCategory_Repose();
        
    }

        public Task CreateCategory(CategoryDTO dto)
        {
            Category c = new Category
            {
                Title = dto.Title,
            };
            return _repose.CreateCategory_Repose(c);
        }
        public async Task UpdateCategory(CardCategoryDTO dto)
        {
            await _repose.UpdateCategory_Repose(dto);
        }

        public async Task DeleteCategory(int id)
        {
        await  _repose.DeleteCategory_Repose(id);
    }
  
    }
}
