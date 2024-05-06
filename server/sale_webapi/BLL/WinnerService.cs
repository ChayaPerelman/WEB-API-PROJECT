using sale_webapi.DAL;
using sale_webapi.Models;

namespace sale_webapi.BLL
{
    public class WinnerService : IWinnerService
    {
        private readonly IWinnerDal _winnerItemDal;
        public WinnerService(IWinnerDal winnerdal)
        {
            this._winnerItemDal = winnerdal;
        }

       

        public async Task<ObjectToRaffle> Raffle(string giftName)
        {

        return await _winnerItemDal.RaffleAsync(giftName);   
        }
        public async Task<List<string>> Creating_a_report_winners()
        {
            return await _winnerItemDal.Creating_a_report_winnersAsync();
        }
    }
}
