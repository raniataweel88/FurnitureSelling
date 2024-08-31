using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.ProductWarranty;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class ProductWarrantyRepose : IProductWarrantyRepose
    {
        private readonly FurnitureSellingDbContext _context;

        public  ProductWarrantyRepose(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        public async Task<ProductWarrantyDTO> GetProductWarrantyById(int id)
        {
            var warranty = await _context.ProductWarrantys.FindAsync(id);
            if (warranty == null) return null;

            return new ProductWarrantyDTO
            {
                ProductWarrantyId = warranty.ProductWarrantyId,
                ItemId = warranty.ItemId,
                WarrantyCode = warranty.WarrantyCode,
                WarrantyStartDate = warranty.WarrantyStartDate,
                WarrantyEndDate = warranty.WarrantyEndDate
            };
        }

        public async Task<List<ProductWarrantyDTO>> GetAllProductWarrantysAsync()
        {
            return await _context.ProductWarrantys
                .Select(w => new ProductWarrantyDTO
                {
                    ProductWarrantyId = w.ProductWarrantyId,
                    ItemId = w.ItemId,
                    WarrantyCode = w.WarrantyCode,
                    WarrantyStartDate = w.WarrantyStartDate,
                    WarrantyEndDate = w.WarrantyEndDate
                })
                .ToListAsync();
        }

        public async Task CreateProductWarrantyAsync(ProductWarranty productWarranty)
        {
            _context.ProductWarrantys.Add(productWarranty);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductWarrantyAsync(ProductWarrantyDTO productWarrantyDto)
        {
            var warranty = await _context.ProductWarrantys.FindAsync(productWarrantyDto.ProductWarrantyId);
            if (warranty == null) return;

            warranty.ItemId = productWarrantyDto.ItemId;
            warranty.WarrantyCode = productWarrantyDto.WarrantyCode;
            warranty.WarrantyStartDate = productWarrantyDto.WarrantyStartDate;
            warranty.WarrantyEndDate = productWarrantyDto.WarrantyEndDate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductWarrantyAsync(int id)
        {
            var warranty = await _context.ProductWarrantys.FindAsync(id);
            if (warranty == null) return;

            _context.ProductWarrantys.Remove(warranty);
            await _context.SaveChangesAsync();
        }
    }
}