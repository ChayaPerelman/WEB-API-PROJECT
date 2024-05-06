using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public interface IGiftService
    {
        Task<List<Gift>> GetGifts();
        Task<DonorDTO> GetTheDonorGift(string name);
        Task<bool> AddGift(Gift gift);
        Task<Gift> UpdateGift(GiftDTO gift,int id);
        Task<bool> DeleteGift(int id);
        Task<List<Gift>> SearchGiftsByAll(string? name, string? donor, int? numOfPurcheses);
    }
}
