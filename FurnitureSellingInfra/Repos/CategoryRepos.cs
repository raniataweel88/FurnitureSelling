using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingInfra.Repos
{
    public class CategoryRepos : ICategoryRepos
    {
        private readonly FurnitureSellingDbContext _context;
        public CategoryRepos(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        public async Task<CardCategoryDTO> GetByIdCategory_Repose(int id)
        {
            Log.Information("start to  GetByIdCategory_Repose");

            var Qery = from c in _context.Categories
                       where c.Id == id
                       select new CardCategoryDTO
                       {
                           Title = c.Title,
                           Id= c.Id,

                       };
            return  Qery.FirstOrDefault();
            Log.Information("finished to  GetByIdCategory_Repose");

        }
        public async Task<List<CardCategoryDTO>> GetAllCategory_Repose()
        {
            Log.Information("start to  GetAllCategory_Repose");

            var Qery = from c in _context.Categories
                       select  new CardCategoryDTO{
                            Title = c.Title,
                           Id = c.Id,
                           };
                 return await Qery.ToListAsync();
            Log.Information("finished to  GetAllCategory_Repose");

        }
        public async Task CreateCategory_Repose(Category c)
        {
            Log.Information("start to  CreateCategory_Repose");
            if (c != null)
            {
                Log.Information("the Category not null");
                await _context.Categories.AddAsync(c);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("the Category is empty");
                throw new Exception("the Category is empty");
            }
            Log.Information("finished to  CreateCategory_Repose");

        }
        public async Task UpdateCategory_Repose(CardCategoryDTO c)
        {
            Log.Information("start to  UpdateCategory_Repose");
            var result = await _context.Categories.FindAsync(c.Id);
            if (result != null)
            {
                //replacement 
                Log.Information("found this Category");
                 result.Id = c.Id;
                 result.Title = c.Title;
                //update
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this Category");
                throw new Exception("can not found this Category");
                  }
           
            Log.Information("finished to  UpdateCategory_Repose");
        }

        public async Task DeleteCategory_Repose(int id)
        {
           
            Log.Information("start to  DeleteCategory_Repose");
            var C = _context.Categories.FirstOrDefault(X => X.Id == id);
            if (C != null)
            {
                Log.Information("found this Category");
                _context.Categories.Remove(C);
                await _context.SaveChangesAsync();
            }
            else
            {
                Log.Error("can not found this Category");
                throw new Exception("can not found this Category");
            }
            Log.Information("Finished to DeleteCategory_Repose");
        }
    }
    }

