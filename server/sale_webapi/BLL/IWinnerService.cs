using sale_webapi.Models;

namespace sale_webapi.BLL
{
    public interface IWinnerService
    {
        Task<ObjectToRaffle> Raffle(string giftName);
        Task<List<string>> Creating_a_report_winners();
    }
}
