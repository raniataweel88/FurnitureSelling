using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingInfra.Repos
{
    public class UserRepos : IUserRepos
    {
        private readonly FurnitureSellingDbContext _context;
        public UserRepos(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        #region User Repos
        public async Task<DetailsUserDTO> GetByIdUserRepos(int Id)
        {
            Log.Debug("start to  GetByIdUserRepos");
            var query = from user in _context.Users
                        where user.UserId == Id
                        select new DetailsUserDTO
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email,
                            Phone = user.Phone,
                        };
          
            return query.FirstOrDefault();
            Log.Debug("finished to  GetByIdUserRepos");

        }
        public async Task<List<CardUserDTO>> GetAllUserRepos()
        {
            Log.Debug("Start to  GetAllUserRepos");

            var quer = from u in _context.Users
                       select new CardUserDTO
                       {
                           Email = u.Email,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           UserId = u.UserId,
                       };
            return quer.ToList();
            Log.Debug("Finished to  GetAllUserRepos ");


        }
        public async Task<int> CreateUserRepos(User u)
        {
           
            Log.Debug("start  CreateUserRepos");
            if (u != null)
            {
                _context.Users.Add(u);
                await _context.SaveChangesAsync();
                return u.UserId;
            }
            else
            {
                Log.Error("User is empty");
                throw new Exception("User is empty");
            }
            Log.Debug("finished to add  CreateUserRepos");
        }
        public async Task CreateLogin(Logins l)
        {
            Log.Debug("start to  CreateLogin_Repose");
            if (l != null)
            {
                _context.Logins.Add(l);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("cann't Login");
                throw new Exception("cann't Login");
            }
                Log.Debug("finished to  CreateLogin_Repose");

            }
            public async Task UpdateUserRepos(DetailsUserDTO dto)
        {
         Log.Debug("start to  UpdateUserRepos");
          var result = await _context.Users.FindAsync(dto.UserId);
            if (result != null)
                {
                Log.Information("found this User");

                //replacement 
                    result.Email = dto.Email;
                    result.FirstName = dto.FirstName;
                    result.LastName = dto.LastName;
                    result.UserId = dto.UserId;
                    result.BirthDate = (DateTime)dto.BirthDate;
                    result.Phone = dto.Phone;
                if (dto.UserType == 0)
                {
                    result.Address = dto.Address;
                }
                if (dto.UserType == 1)
                {
                    result.Salary = dto.Salary;
                }
                if (dto.UserType == 4)
                {
                    result.PlateNumber = dto.PlateNumber;
                }
                //update
                _context.Update(result);
                    await _context.SaveChangesAsync();
                Log.Information("update this user",result.UserId);

            }
            else
            {
                Log.Error("can not found this User");
                throw new Exception("can not found this User");
            }
            Log.Debug("finished to  UpdateUserRepos");

        }
        public async Task DeleteUser(int Id)
        {
            var user =  _context.Users.FirstOrDefault(x=>x.UserId==Id);
                 
            Log.Debug("start to  DeleteUser_Repose");
            if (user != null)
            {
                
                _context.Remove(user);
                await _context.SaveChangesAsync();
                Log.Information("delete this user");
            }
            else
            {
                Log.Error("can not found this User");
                throw new Exception("can not found this User");
            }
            Log.Debug("Finished to DeleteUser_Repose");
        }
        
        #endregion
        #region Authantication Repos

        public async Task Login(int Id)
        {
            Log.Debug("start to  Login_Repose");

            var r =_context.Logins.Find(Id);
            if(r != null)
            {
            r.IsLoggedIn=true;
            r.LastLoginTime = DateTime.Now;
                _context.Update(r);
                await _context.SaveChangesAsync();
                Log.Information("Login true");
            }
           else
            {
                Log.Error("Can not login");
                throw new Exception("Con not login");
                  }
   
            Log.Debug("finished to  Login_Repose");

        }

   

        public async Task Logout(int Id)
        {
            Log.Information("start to  Logout_Repose");

            var l = _context.Logins.FirstOrDefault(x=>x.LoginId==Id);
            if (l.IsLoggedIn==true)
            {
                l.IsLoggedIn=false;
                _context.Update(l);
              await  _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Can not Logout");
                Log.Error("Con not Logout");
            }
            Log.Information("finished to  Logout_Repose");

        }

        public async Task ResetPassword(ResetPasswordDTO dto)
        {
            Log.Information("start to  ResetPasswordDTO");
            var l = _context.Logins.FirstOrDefault(x => x.LoginId.Equals(dto.Id));
         
            if (l != null)
            {
                l.Password=dto.NewPassword;
                l.LoginId=dto.Id;
                _context.Update(l);
                await _context.SaveChangesAsync();
             
            }
            else
            {
                throw new Exception("Con not ResetPassword");
                Log.Error("Con not ResetPassword");
            }
            Log.Information("finished to  ResetPasswordDTO");

        }




        #endregion

    }
}
