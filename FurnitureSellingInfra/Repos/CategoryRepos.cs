using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    internal class CategoryRepos : ICategoryRepos
    {
        public Task CreateCategory_Repose(Category c)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategory_Repose()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdCategory_Repose(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory_Repose(Category c)
        {
            throw new NotImplementedException();
        }
    }
}
