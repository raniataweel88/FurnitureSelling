using FurnitureSellingCore.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IUserServices
    {
        public Task CreateUser(CreateUserDTO dto);

        public Task<DetailsUserDTO> GetByIdUser(int Id);
        public Task<CardUserDTO> GetAllUser();
        public Task UpdateUser(DetailsUserDTO dto);
        public Task DeleteUser(int Id);
    }
}
