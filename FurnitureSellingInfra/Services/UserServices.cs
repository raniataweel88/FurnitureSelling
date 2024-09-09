using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.helper;
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
        public async Task<DetailsUserDTO> GetUserById(int Id)
        {
            Log.Debug("start GetByIdUser-Services", Id);
          var user = await _repos.GetByIdUserRepos(Id);
            if (user == null)
            {
                throw new Exception("doesn't have this profile");
            }
            else
            {
                return user;
            }
        }

        public async Task<List<CardUserDTO>> GetAllUser()
        {
            Log.Debug("start GetAllUser-Services");
            return  await _repos.GetAllUserRepos();
           
        }
        public async Task<int> CreateUser(CreateUserDTO dto)
        {
            Log.Debug("start CreateUser-Services");
            User u = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserType = "user",
            }
            ;
            
            int user_Id = await _repos.CreateUserRepos(u);
            var usrname = dto.FirstName + " " + dto.LastName;
            Logins l = new Logins()
            {
               UserName= HashHelper.GenerateSHA384String(usrname),
                Password =HashHelper.GenerateSHA384String( dto.Password),
                UserId = user_Id
            };
            await _repos.CreateLogin(l);
            return user_Id;
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
        public async Task<int> Login(LoginDTO l)
        {
            Log.Debug("Start Login-Services");

       
            return await _repos.LoginId(l);
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

        public async Task<string> GenerateUserAccessToken(LoginDTO l)
        {
            var user = await TryAthinticate(l);

            if (user == null)
            {
                Log.Error("User authentication failed");
                throw new Exception("Cannot generate token: authentication failed");
            }

            return TokenHelper.GenerateJwtToken(user);
        }


        public async  Task<DetailsUserDTO> TryAthinticate(LoginDTO l)
        {
           l.UserName =HashHelper.GenerateSHA384String(l.UserName);
            l.Password = HashHelper.GenerateSHA384String(l.Password);
            int userId =await _repos.Login(l);
            if (userId != 0)
                return await _repos.GetByIdUserRepos(userId);
            else
                throw new Exception(" worng in email or  passwors");
        }

        public async Task CreateUserAdmain(DetailsUserAdmainDTO dto)
        {
            Log.Debug("start CreateUser-Services");
            User u = new User();

            u.FirstName = dto.FirstName;
             u.LastName = dto.LastName;
            u.PlateNumber = dto.PlateNumber;
            u.Salary = dto.Salary;
            u.UserType = dto.UserType;
            u.Email = dto.Email;
            var username = dto.FirstName + " " + dto.LastName;
           
                int user_Id = await _repos.CreateUserReposAdmain(u);
            Logins l = new Logins()
            {
                UserName = HashHelper.GenerateSHA384String(username),
                Password = HashHelper.GenerateSHA384String(dto.password),
                UserId = user_Id
            };
            await _repos.CreateLogin(l);

        }

        #endregion
    }
}
