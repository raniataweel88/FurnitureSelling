using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    internal class OrderRepos : IOrderRepos
    {
        public Task CreateOrder_Repose(Order o)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdOrder_Repose(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(Order dto)
        {
            throw new NotImplementedException();
        }
    }
}
