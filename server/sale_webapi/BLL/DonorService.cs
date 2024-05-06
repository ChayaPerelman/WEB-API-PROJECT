using AutoMapper;
using sale_webapi.DAL;
using sale_webapi.Models.DTO;
using server.Models;
using System.Drawing;

namespace sale_webapi.BLL
{

    public class DonorService : IDonorservice
    {
        private readonly IDonorDal _donorDal;
        IMapper _mapper;
        public DonorService(IDonorDal donorDal, IMapper mapper)
        {
            this._donorDal = donorDal;
            this._mapper = mapper;
        }
        public async Task<List<Donor>> GetDonors()
        {
            return await _donorDal.GetDonorsAsync();
        }

        public async Task<List<Gift>> GetGiftsByDonorId(int id)
        {
            return await _donorDal.GetGiftsByDonorIdAsync(id);
        }
        public async Task<bool> AddDonor(Donor donor)
        {
            return await _donorDal.AddDonorAsync(donor);
        }

        public async Task<Donor> UpdateDonor(DonorDTO donorDTO,int id)
        {
            Donor _donor = _mapper.Map<Donor>(donorDTO);
            return await _donorDal.UpdateDonorAsync(_donor, id);
        }

        public async Task<bool> DeleteDonor(int id)
        {
            await _donorDal.DeleteDonorAsync(id);
            return true;
        }

        public async Task<List<Donor>> SearchDonorsByAll(string? fName, string? lName, string? email, string? giftName, string? phoneNumber)
        {
            List<Donor> donors = await _donorDal.SearchDonorsByAllAsync( fName, lName,  email, giftName, phoneNumber);
            return donors;
            
        }
    }

}



