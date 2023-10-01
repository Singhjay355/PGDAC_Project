using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.Cartfolder
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext context;

        public CartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Cart> SaveCart(Cart cart)
        {
            context.Carts.Add(cart);
            await context.SaveChangesAsync();
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            var carts = await context.Carts.ToListAsync();
            return carts;
        }

        public async Task<Cart> GetCartById(int id)
        {
            var cart = await context.Carts.FindAsync(id);
            return cart;
        }

        public async Task DeleteCart(int id)
        {
            var cartToDelete = await context.Carts.FindAsync(id);
            if (cartToDelete != null)
            {
                context.Carts.Remove(cartToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Cart> UpdateCart(Cart cart, int id)
        {
            if (id != cart.CartID)
            {
                return null;
            }

            context.Entry(cart).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return cart;
        }

        private bool CartExists(int id)
        {
            return context.Carts.Any(e => e.CartID == id);
        }
    }
}
