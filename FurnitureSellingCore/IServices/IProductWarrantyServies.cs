using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.DTO.ProductWarranty;
using FurnitureSellingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.IServices
{
    public interface IProductWarrantyServies
    {
        public Task<ProductWarrantyDTO> GetProductWarrantyById(int id);
        public Task<List<ProductWarrantyDTO>> GetAllProductWarranties();
        public Task CreateProductWarranty(CreateProductWarrantyDTO dto);
        public Task UpdateProductWarranty(ProductWarrantyDTO dto);
        public Task DeleteProductWarranty(int id);
    }
}
