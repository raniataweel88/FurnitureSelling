using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class UserRepos : IUserRepos
    {
        public Task CreateUserRepos(User u)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUserRepos()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdUserRepos(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRepos(User u)
        {
            throw new NotImplementedException();
        }
    }
}
