﻿
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface ICartRepos
    {
        public Task CreateCart_Repose(Cart c);
       
        public Task<Cart> GetByIdCart_Repose(int Id);
        public Task<List<Cart>> GetAllCart_Repose();
        public Task UpdateCart_Repose(Cart c);
    }
}