using FurnitureSellingCore.DTO.Authantication;
using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IUserRepos
    {
        #region User Repos
        public Task<int> CreateUserRepos(User u);
        public Task<int> CreateUserReposAdmain(User u);
        public Task<DetailsUserDTO> GetByIdUserRepos(int Id);
        public Task<List<CardUserDTO>> GetAllUserRepos();
        public Task UpdateUserRepos(DetailsUserDTO u);
        public Task DeleteUser(int Id);

        #endregion 
        #region Authantication-Services
        public Task CreateLogin(Logins l);
        public Task Logout(int Id);
        public Task<int> Login(LoginDTO l);
        public Task<int> LoginId(LoginDTO l);

        public Task ResetPassword(ResetPasswordDTO dto) ;

        #endregion

    }
}
