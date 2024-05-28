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
        public Task CreateCategory(CategoryDTO dto);
        public Task DeleteCategory(int id);
        public Task UpdateCategory(CategoryDTO dto);
        public Task<CategoryDTO> GetAllCategory();
        public Task<CategoryDTO> GetByIdCategory(int id);

    }
}
