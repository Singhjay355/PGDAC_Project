using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.Productfolder
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProduct(int productId)
        {
            Product product = await context.Products.FindAsync(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductById(int productId)
        {
            var product = await context.Products.FindAsync(productId);
            return product;
        }

        public async Task<Product?> UpdateProduct(int productId, Product updatedProduct)
        {
            if (productId != updatedProduct.prodID)
            {
                return null;
            }

            context.Entry(updatedProduct).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(productId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return updatedProduct;
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRange(double minPrice, double maxPrice)
        {
            var products = await context.Products
                .Where(p => p.mrpPrice >= minPrice && p.mrpPrice <= maxPrice)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsWithValidDiscount()
        {
            var products = await context.Products
                .Where(p => p.offerPrice < p.mrpPrice)
                .ToListAsync();

            return products;
        }

        private bool ProductExists(int productId)
        {
            return context.Products.Any(e => e.prodID == productId);
        }
    }
}
