using Microsoft.AspNetCore.Mvc;
using Emart_final.Models;
namespace Emart_final.Repository.Categoryfolder
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);

        Task<Category?> DeleteCategory(int categoryId);

        Task<ActionResult<IEnumerable<Category>>> GetAllCategories();

        Task<Category?> GetCategoryById(int id);

        Task<Category?> GetCategoriesByCategoryByName(string categoryname);

        Task<Category?> UpdateCategory(int  categoryId, Category category);
    }
}
