using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.DAL
{
    public interface IGiftDal
    {
        Task<List<Gift>> GetGiftsAsync();
        Task<DonorDTO> GetTheDonorGiftAsync(string name);
        Task<bool> AddGiftAsync(Gift gift);
        Task<Gift> UpdateGiftAsync(Gift gift, int id);
        Task<bool> DeleteGiftAsync(int id);
        Task<List<Gift>> SearchGiftsByAllAsync(string? name, string? donor, int? numOfPurcheses);

    }
}
