using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface ILoginRepose
    {
        public Task CreateLogin_Repose(Login l);
        public Task<Login> GetByIdLogin_Repose(int id);
        public Task<List<Login>> GetAllLogin_Repose();
        public Task UpdateLogin_Repose(Login l);
    }
}
