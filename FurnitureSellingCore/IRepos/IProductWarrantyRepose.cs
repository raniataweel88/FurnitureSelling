using Azure;
using FurnitureSellingCore.DTO.ProductWarranty;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IRepos
{
    public interface IProductWarrantyRepose
    {
        public Task<ProductWarrantyDTO> GetProductWarrantyById(int id);
        public Task<List<ProductWarrantyDTO>> GetAllProductWarrantysAsync();
        public Task CreateProductWarrantyAsync(ProductWarranty dto);
        public Task UpdateProductWarrantyAsync(ProductWarrantyDTO dto);
        public Task DeleteProductWarrantyAsync(int id);
    }
}
