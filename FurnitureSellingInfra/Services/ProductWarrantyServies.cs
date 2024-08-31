using FurnitureSellingCore.DTO.ProductWarranty;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.IServices;
using FurnitureSellingCore.Models;

namespace FurnitureSellingInfra.Services
{
    public class ProductWarrantyServies : IProductWarrantyServies
    {

        private readonly IProductWarrantyRepose _repose;

        public ProductWarrantyServies(IProductWarrantyRepose repose)
        {
            _repose = repose;
        }

        public async Task<ProductWarrantyDTO> GetProductWarrantyById(int id)
        {
            return await _repose.GetProductWarrantyById(id);
        }

        public async Task<List<ProductWarrantyDTO>> GetAllProductWarranties()
        {
            return await _repose.GetAllProductWarrantysAsync();
        }

        public async Task CreateProductWarranty(CreateProductWarrantyDTO dto)
        {
            var productWarranty = new ProductWarranty
            {
                ItemId = dto.ItemId,
                WarrantyCode = dto.WarrantyCode,
                WarrantyStartDate = dto.WarrantyStartDate,
                WarrantyEndDate = dto.WarrantyEndDate
            };

            await _repose.CreateProductWarrantyAsync(productWarranty);
        }

        public async Task UpdateProductWarranty(ProductWarrantyDTO dto)
        {
            await _repose.UpdateProductWarrantyAsync(dto);
        }

        public async Task DeleteProductWarranty(int id)
        {
            await _repose.DeleteProductWarrantyAsync(id);
        }
    }

}
