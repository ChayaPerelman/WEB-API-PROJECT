using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.DAL
{
    public class GiftDal:IGiftDal
    {
        private readonly OrdersContext _orderContext;
        private readonly IMapper _mapper;
        private readonly ILogger<Gift> _logger;

        public GiftDal(OrdersContext orderContext, IMapper mapper, ILogger<Gift> logger)
        {
            this._orderContext = orderContext;
            this._mapper = mapper;
            _logger = logger;
        }
        public async Task<List<Gift>> GetGiftsAsync()
        {
            return await _orderContext.Gift.ToListAsync();
        }
        public async Task<DonorDTO> GetTheDonorGiftAsync(string name)
        {
            var gift = await _orderContext.Gift
            .FirstOrDefaultAsync(g => g.Name == name);
            var donor = await _orderContext.Donor
            .FirstOrDefaultAsync(d => d.DonorId == gift.DonorId);
            DonorDTO _donorDTO = _mapper.Map<DonorDTO>(donor);
            return _donorDTO;  
        }


        public async Task<bool> AddGiftAsync(Gift gift)
        {
            await _orderContext.Gift.AddAsync(gift);
            _orderContext.SaveChanges();
            return true;
        }

        public async Task<Gift> UpdateGiftAsync(Gift gift,int id)
        {
            var giftToUpdate = await _orderContext.Gift.FirstAsync(g => id == g.GiftId);
            if (giftToUpdate != null)  
                giftToUpdate.Name = gift.Name;
                giftToUpdate.Category = gift.Category;
                giftToUpdate.Cost = gift.Cost;
                giftToUpdate.Donor = gift.Donor;
                giftToUpdate.DonorId = gift.DonorId;
                giftToUpdate.Image = gift.Image;
            _orderContext.Update(giftToUpdate);
           await _orderContext.SaveChangesAsync();
            return giftToUpdate;
        }

        public async Task<bool> DeleteGiftAsync(int id)
        {
            var giftToDelete = await _orderContext.Gift.FirstOrDefaultAsync(g => g.GiftId == id);
            _orderContext.Gift.Remove(giftToDelete);
            _orderContext.SaveChanges();
            return true;
        }

        public async Task<List<Gift>> SearchGiftsByAllAsync(string? name, string? donor, int? numOfPurcheses)

        {
            //var query = _orderContext.Gift.Where(gift =>
            //(name == null ? (true) : (gift.Name == name))
            ////&& ((donor == null) ? (true) : (_orderContext.Gift.Include(g=> _orderContext.Donor.Where(d=> d.FirstName == donor).Select(g=> g.))))
            ////&& ((email == null) ? (true) : (donor.Email == email))
            ////&& ((giftName == null) ? (true) : (donor.gifts.FirstOrDefault(g => g.Name == giftName)) != null)
            //);
            //Console.WriteLine(query.ToQueryString());
            //List<Gift> gifts = await query.ToListAsync();
            //return gifts;






            var query = _orderContext.Gift
                .Include(g => g.Donor)
                .Where(g =>
                    (name == null ? (true) : (g.Name.Contains(name))) &&
                    (donor == null || g.Donor.FirstName.Contains(donor)) &&
                    (numOfPurcheses == null ? true : _orderContext.OrderItem.Count(oi => oi.GiftId == g.GiftId) == numOfPurcheses)

                    );
            List<Gift> gifts = await query.ToListAsync();
            return gifts;

        }

    }
}
