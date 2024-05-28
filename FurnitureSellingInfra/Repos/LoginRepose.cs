using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class LoginRepose : ILoginRepose
    {
        public Task CreateLogin_Repose(Login l)
        {
            throw new NotImplementedException();
        }

        public Task<List<Login>> GetAllLogin_Repose()
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetByIdLogin_Repose(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLogin_Repose(Login l)
        {
            throw new NotImplementedException();
        }
    }
}
