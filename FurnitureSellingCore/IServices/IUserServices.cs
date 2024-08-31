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
      public Task<int> CreateUser(CreateUserDTO dto);
        public Task CreateUserAdmain(DetailsUserAdmainDTO dto);

        public Task<DetailsUserDTO> GetUserById(int Id);
        public Task<List<CardUserDTO>> GetAllUser();
        public Task UpdateUser(DetailsUserDTO dto);
        public Task DeleteUser(int Id);
        #endregion


        #region Authantication-Services
        public Task<int> Login(LoginDTO l);
        public Task Logout(int Id);
        public Task<string> GenerateUserAccessToken(LoginDTO d);
        public Task<DetailsUserDTO> TryAthinticate(LoginDTO l);

        public Task ResetPassword(ResetPasswordDTO d);

        #endregion
    }
}
