
using server.Models;
using System.Drawing;


namespace sale_webapi.DAL
{
    public class DonorDal : IDonorDal
    {
        private readonly OrdersContext _orderContext;
        public DonorDal(OrdersContext orderContext)
        {
            this._orderContext = orderContext;
        }
        public async Task<List<Donor>> GetDonorsAsync()
        {
            return await _orderContext.Donor.ToListAsync();
        }
        public async Task<List<Gift>> GetGiftsByDonorIdAsync(int id)
        {
            List<Gift> gifts = await _orderContext.Gift
                .Where(d => d.DonorId == id)
                .ToListAsync();
            return gifts;
        }
        
        public async Task<bool> AddDonorAsync(Donor donor)
        {
            await _orderContext.Donor.AddAsync(donor);
            _orderContext.SaveChanges();
            return true;
        }

        //public async Task<Donor> UpdateDonorAsync(Donor donor)
        //{
        //    var donorToUpdate = await _orderContext.Donor.FirstAsync(d => donor.DonorId == d.DonorId);
        //    if (donorToUpdate != null)
        //        donorToUpdate.FirstName = donor.FirstName;
        //    donorToUpdate.LastName = donor.LastName;
        //    donorToUpdate.PhonNumber = donor.PhonNumber;
        //    donorToUpdate.Email = donor.Email;
        //    _orderContext.SaveChanges();
        //    return donorToUpdate;
        //}

        public async Task<Donor> UpdateDonorAsync(Donor donor, int id)
        {
            var donorToUpdate = await _orderContext.Donor.FirstAsync(d => id == d.DonorId);
            if (donorToUpdate != null)
                donorToUpdate.FirstName = donor.FirstName;
            donorToUpdate.LastName = donor.LastName;
            donorToUpdate.PhonNumber = donor.PhonNumber;
            donorToUpdate.Email = donor.Email;
            _orderContext.Update(donorToUpdate);
            await _orderContext.SaveChangesAsync();
            return donorToUpdate;
        }


        public async Task<bool> DeleteDonorAsync(int id)
        {
            var donorToDelete = await _orderContext.Donor.FirstAsync(d => d.DonorId == id);
            _orderContext.Donor.Remove(donorToDelete);
            _orderContext.SaveChanges();
            return true;
        }

        public async Task<List<Donor>> SearchDonorsByAllAsync( string? fName, string? lName, string? email, string? giftName, string? phoneNumber)
        {
            //var gift = _orderContext.Donor.FirstOrDefault(d => d.gifts.FirstOrDefault(g => g.Name == giftName))
            var query = _orderContext.Donor.Where(donor => 
            (fName == null ? (true) : (donor.FirstName == fName))
            && ((lName == null)? (true) : (donor.LastName == lName))
            && ((email == null) ? (true) : (donor.Email == email))
              && ((phoneNumber == null) ? (true) : (donor.PhonNumber == phoneNumber))
            && ((giftName == null) ? (true) : (donor.gifts.FirstOrDefault(g => g.Name == giftName)) != null)
            );
            Console.WriteLine(query.ToQueryString());
            List<Donor> donors = await query.ToListAsync();
            return donors;
        }
    }  
}
