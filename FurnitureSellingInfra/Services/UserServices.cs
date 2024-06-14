using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingInfra.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepos _repos;
        public UserServices(IUserRepos repos)
        {
            _repos = repos;
        }
        #region User Services
        public async Task<DetailsUserDTO> GetByIdUser(int Id)
        {
            Log.Debug("start GetByIdUser-Services", Id);
            var user = await _repos.GetByIdUserRepos(Id);

            return user;
        }

        public async Task<List<CardUserDTO>> GetAllUser()
        {
            Log.Debug("start GetAllUser-Services");
            return  await _repos.GetAllUserRepos();
           
        }
        public async Task CreateUser(CreateUserDTO dto)
        {
            Log.Debug("start CreateUser-Services");
            User u = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserType = dto.UserType,
            }
            ;
            
            int user_Id = await _repos.CreateUserRepos(u);
            Logins l = new Logins()
            {
               UserName=dto.FirstName+" "+dto.LastName,
                Password = dto.Password,
                UserId = user_Id
            };
            await _repos.CreateLogin(l);
            
        }

        public async Task UpdateUser(DetailsUserDTO dto)
        {
            Log.Debug("start UpdateUser-Services", dto.UserId);
            await _repos.UpdateUserRepos(dto);

        }
        public async Task DeleteUser(int Id)
        {
            Log.Debug("start DeleteUser-Services", Id);
            await _repos.DeleteUser(Id);
        }
        #endregion
        #region Authantication Services
        public async Task Login(int Id)
        {
            Log.Debug("start Login-Services", Id);
            await _repos.Login(Id);
        }

        public async Task Logout(int Id)
        {
            Log.Debug("start Logout-Services", Id);
            await  _repos.Logout(Id);   
        }

        public async Task ResetPassword(ResetPasswordDTO dto)
        {
            Log.Debug("start ResetPassword-Services");
            await _repos.ResetPassword(dto);
        }

        #endregion
    }
}
