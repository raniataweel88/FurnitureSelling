using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    internal class CartRepos : ICartRepos
    {
        public Task CreateCart_Repose(Cart c)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetAllCart_Repose()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetByIdCart_Repose(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCart_Repose(Cart c)
        {
            throw new NotImplementedException();
        }
    }
}
