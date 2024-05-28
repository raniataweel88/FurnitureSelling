using FurnitureSellingCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface ILoginServices
    {
        public Task CreateLogin(LoginDTO dto);
        public Task DeleteLogin(int id);
        public Task<LoginDTO> GetByIdLogin(int id);
        public Task<LoginDTO> GetAllLogin();
        public Task UpdateLogin(LoginDTO dto);
    }
}
