using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class UserServices : IUserServices
    {
        public Task CreateUser(CreateUserDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CardUserDTO> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<DetailsUserDTO> GetByIdUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(DetailsUserDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
