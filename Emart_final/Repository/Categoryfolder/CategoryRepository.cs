using Emart_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.Categoryfolder
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int categoryId)
        {
            Category category = await context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
            return category;
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            var category = await context.Categories.FindAsync(id);
            return category;
        }


        public async Task<Category?> GetCategoriesByCategoryByName(string categoryname)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.categoryName == categoryname);
            return category;
        }

        public async Task<Category?> UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.catmasterID)
            {
                return null;
            }

            context.Entry(category).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(categoryId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return category;
        }

        private bool CategoryExists(int categoryId)
        {
            return context.Categories?.Any(e => e.catmasterID == categoryId) ?? false;
        }
    }
}
