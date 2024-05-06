using sale_webapi.DAL;
using sale_webapi.Models;
using server.Models;

namespace sale_webapi.BLL
{
    public class HomeService : IHomeService
    {
        private readonly IHomeDal _homeDal;
        public HomeService(IHomeDal homeDal)
        {
            this._homeDal = homeDal;
        }

        public async Task<bool> AddToCart(Gift gift)
        {
            return await _homeDal.AddToCartAsync(gift);
        }

        public async Task<List<Gift>> GetAllGifts()
        {
            return await _homeDal.GetAllGiftsAsync();
        }
    }
}