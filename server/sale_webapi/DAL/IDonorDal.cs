using server.Models;

namespace sale_webapi.DAL
{
    public interface IDonorDal
    {
        Task<List<Donor>> GetDonorsAsync();
        Task<List<Gift>> GetGiftsByDonorIdAsync(int id);

        Task<bool> AddDonorAsync(Donor donor);
        Task<Donor> UpdateDonorAsync(Donor donor, int id);
        Task<bool> DeleteDonorAsync(int id);

        Task<List<Donor>> SearchDonorsByAllAsync(string? fName, string? lName, string? email, string? giftName, string? phoneNumber);
       
    }
}
