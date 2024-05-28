using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IOrderRepos
    {
        public Task CreateOrder_Repose(Order o);

        public Task<Order> GetByIdOrder_Repose(int id);
        public Task<List<Order>> GetAllOrder();
        public Task UpdateOrder(Order dto);

    }
}
