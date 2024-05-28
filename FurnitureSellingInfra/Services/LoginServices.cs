using FurnitureSellingCore.DTO;
using FurnitureSellingCore.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class LoginServices : ILoginServices
    {
        public Task CreateLogin(LoginDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLogin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LoginDTO> GetAllLogin()
        {
            throw new NotImplementedException();
        }

        public Task<LoginDTO> GetByIdLogin(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateLogin(LoginDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
