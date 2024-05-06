using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.DAL
{
    public interface IOrderDal
    {

        Task<List<Order>> GetOrderAsync();
        
        Task<List<Order>> GetOrderByGiftAsync(string giftName);
        Task<List<AppUserDTO>> GetPurchasersAsync();
        Task<List<Order>> SearchPurchaserGiftsAsync();
        Task<bool> addNewOrderAsync(int userId);
        Task<int> payAsync(int orderId);
   

    }
}





