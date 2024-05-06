using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public interface IDonorservice
    {
        Task<List<Donor>> GetDonors();
        Task<List<Gift>> GetGiftsByDonorId(int id);
        Task<bool> AddDonor(Donor donor);
        Task<Donor> UpdateDonor(DonorDTO donorDTO,int  id);
        Task<bool> DeleteDonor(int id);
        Task<List<Donor>> SearchDonorsByAll( string? fName, string? lName, string? email, string? giftName,string? phoneNumber);
    }
}
