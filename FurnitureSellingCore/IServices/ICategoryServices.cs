using FurnitureSellingCore.DTO.Catagory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface ICategoryServices
    {        
        public Task<CardCategoryDTO> GetByIdCategory(int id);
        public Task<List<CardCategoryDTO>> GetAllCategory();
        public Task CreateCategory(CategoryDTO dto);
        public Task UpdateCategory(CardCategoryDTO dto);
        public Task DeleteCategory(int id);
        public Task<addmin> Expectations();

    }
}
