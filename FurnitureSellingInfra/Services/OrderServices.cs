using FurnitureSellingCore.DTO.Order;
using FurnitureSellingCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Services
{
    internal class OrderServices : IOrderServices
    {
        public Task CreateOrder(CreateOrderDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CardOrdertDTO> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<DetailsOrdertDTO> GetByIdOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(DetailsOrdertDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
