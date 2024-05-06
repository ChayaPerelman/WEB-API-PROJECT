using sale_webapi.Models;
using server.Models;

namespace sale_webapi.BLL
{
    public interface IHomeService
    {
        Task<List<Gift>> GetAllGifts();
        Task<bool> AddToCart(Gift gift);
    }
}
