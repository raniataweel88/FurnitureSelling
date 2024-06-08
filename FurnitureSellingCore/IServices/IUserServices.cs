using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IUserServices
    {
        #region User Services
      public Task CreateUser(CreateUserDTO dto);

        public Task<DetailsUserDTO> GetByIdUser(int Id);
        public Task<List<CardUserDTO>> GetAllUser();
        public Task UpdateUser(DetailsUserDTO dto);
        public Task DeleteUser(int Id);
        #endregion


        #region Authantication-Services
        public  Task Login(int id);
        public Task Logout(int Id);
         
        public Task ResetPassword(ResetPasswordDTO d);

        #endregion
    }
}
