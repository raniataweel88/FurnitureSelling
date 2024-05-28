using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureSellingCore.Models;

namespace FurnitureSellingCore.IRepos
{
    public interface ICategoryRepos
    {
        public Task CreateCategory_Repose(Category c);
        public Task UpdateCategory_Repose(Category c);
        public Task<List<Category>> GetAllCategory_Repose();
public Task<Category> GetByIdCategory_Repose(int id);


    }
}
