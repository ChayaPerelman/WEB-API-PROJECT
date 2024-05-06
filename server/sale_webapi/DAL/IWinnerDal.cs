using sale_webapi.Models;

namespace sale_webapi.DAL
{
    public interface IWinnerDal
    {
        Task<ObjectToRaffle> RaffleAsync(string giftName);
        Task<List<string>> Creating_a_report_winnersAsync();
    }
}
