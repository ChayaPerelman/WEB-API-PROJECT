using sale_webapi.DAL;
using server.Models;
using sale_webapi;
using AutoMapper;
using sale_webapi.Models.DTO;

namespace sale_webapi.BLL
{
    public class GiftService:IGiftService
    {
        private readonly IGiftDal _giftDal;
        IMapper _mapper;
        public GiftService(IGiftDal giftDal, IMapper mapper)
        {
            this._giftDal = giftDal;
            this._mapper = mapper;
        }

        public async Task<List<Gift>> GetGifts()
        {
            return await _giftDal.GetGiftsAsync();
        }

        public async Task<DonorDTO> GetTheDonorGift(string name)
        {
            return await _giftDal.GetTheDonorGiftAsync( name);
        }

        public async Task<bool> AddGift(Gift gift)
        {
            return await _giftDal.AddGiftAsync(gift);
        }

        public async Task<Gift> UpdateGift(GiftDTO gift, int id)
        {
            Gift _gift = _mapper.Map<Gift>(gift);
            return await _giftDal.UpdateGiftAsync(_gift, id);
        }

        public async Task<bool> DeleteGift(int id)
        {
            await _giftDal.DeleteGiftAsync(id);
            return true;
        }

        public async Task<List<Gift>> SearchGiftsByAll(string? name, string? donor, int? numOfPurcheses)
        {
            return await _giftDal.SearchGiftsByAllAsync( name, donor, numOfPurcheses);
        }
    }
}
