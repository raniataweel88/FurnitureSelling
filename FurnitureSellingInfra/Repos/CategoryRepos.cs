using FurnitureSellingCore.Context;
using FurnitureSellingCore.DTO.Catagory;
using FurnitureSellingCore.IRepos;
using FurnitureSellingCore.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FurnitureSellingInfra.Repos
{
    public class CategoryRepos : ICategoryRepos
    {
        private readonly FurnitureSellingDbContext _context;
        public CategoryRepos(FurnitureSellingDbContext context)
        {
            _context = context;
        }
        public async Task<CardCategoryDTO> GetByIdCategory_Repose(int Id)
        {
            Log.Debug("start to  GetByIdCategory_Repose");

            var Qery = from c in _context.Categories
                       where c.Id == Id

                       select new CardCategoryDTO
                       {
                           Title = c.Title,
                           Id = c.Id,

                       };
            Log.Debug("finished to  GetByIdCategory_Repose");
            return Qery.FirstOrDefault();
        }
        public async Task<List<CardCategoryDTO>> GetAllCategory_Repose()
        {
            Log.Debug("start to  GetAllCategory_Repose");

            var Qery = from c in _context.Categories
                       select new CardCategoryDTO
                       {
                           Title = c.Title,
                           Id = c.Id,
                       };
            Log.Debug("finished to  GetAllCategory_Repose");
            return await Qery.ToListAsync();

        }
        public async Task CreateCategory_Repose(Category c)
        {
            Log.Debug("start to  CreateCategory_Repose");
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
            Log.Debug("finished to  CreateCategory_Repose");

        }
        public async Task UpdateCategory_Repose(CardCategoryDTO c)
        {
            Log.Debug("start to  UpdateCategory_Repose");
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

            Log.Debug("finished to  UpdateCategory_Repose");
        }

        public async Task DeleteCategory_Repose(int Id)
        {

            Log.Debug("start to  DeleteCategory_Repose");
            var C = _context.Categories.FirstOrDefault(X => X.Id == Id);
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
            Log.Debug("Finished to DeleteCategory_Repose");
        }
    
    
        public async Task<addmin> Expectations()
        {
            var C =  _context.Categories.Count();
            var i = _context.Items.Count();
            var u = _context.Users.Count();
            var o = _context.Orders.Count();
            addmin a = new addmin()
            {
                Categorynumber = C,
                Itemnumber = i,
                salear = o,
                UserNumber = u,
            };
            return a;
        }

    }
    }

