using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.Models;

namespace FurnitureSellingCore.IRepos
{
    public interface ICategoryRepos
    {
        public Task<CardCategoryDTO> GetByIdCategory_Repose(int id);
        public Task<List<CardCategoryDTO>> GetAllCategory_Repose();
        public Task CreateCategory_Repose(Category c);
        public Task UpdateCategory_Repose(CardCategoryDTO c);
        public Task DeleteCategory_Repose(int id);
        public  Task<addmin> Expectations();
 }
}
