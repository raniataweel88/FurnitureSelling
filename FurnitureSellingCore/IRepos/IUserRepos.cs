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
        public Task CreateUserRepos(User u);

        public Task<User> GetByIdUserRepos(int Id);
        public Task<List<User>> GetAllUserRepos();
        public Task UpdateUserRepos(User u);

    }
}
