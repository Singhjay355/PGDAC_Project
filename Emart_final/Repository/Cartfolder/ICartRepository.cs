using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Repository.Cartfolder
{
    public interface ICartRepository
    {
        Task<Cart> SaveCart(Cart cart);

        Task<IEnumerable<Cart>> GetAllCarts();

        Task<Cart> GetCartById(int id);

        Task DeleteCart(int id);

        Task<Cart> UpdateCart(Cart cart, int id);
    }
}
