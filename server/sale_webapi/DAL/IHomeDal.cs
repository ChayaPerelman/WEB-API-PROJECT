using sale_webapi.Models;
using server.Models;

namespace sale_webapi.DAL
{
    public interface IHomeDal
    {
        Task<List<Gift>> GetAllGiftsAsync();
        Task<bool> AddToCartAsync(Gift gift);
    }
}
