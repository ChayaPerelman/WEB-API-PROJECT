using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrder();
        Task<List<Order>> GetOrderByGift(string giftName);
        Task<List<Order>> SearchPurchaserGifts();
        Task<List<AppUserDTO>> GetPurchasers();
        Task<bool> addNewOrder(int userID);
        Task<int> pay(int orderId);
    }
}
