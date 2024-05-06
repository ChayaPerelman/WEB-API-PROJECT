using sale_webapi.DAL;
using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderService(IOrderDal orderDal)
        {
            this._orderDal = orderDal;
        }

        public async Task<bool> addNewOrder(int userId)
        {  
            bool res=await _orderDal.addNewOrderAsync(userId);
            return res;
        }

        public async Task<List<Order>> GetOrder()
        {
            return await _orderDal.GetOrderAsync();
        }

        public async Task<List<Order>> GetOrderByGift(string giftName)
        {
            return await _orderDal.GetOrderByGiftAsync(giftName);
        }

        public async Task<List<AppUserDTO>> GetPurchasers()
        {
            return await _orderDal.GetPurchasersAsync();
        }

        public async Task<int> pay(int orderId)
        {
            return await _orderDal.payAsync(orderId);
        }

        public Task<List<Order>> SearchPurchaserGifts()
        {
            throw new NotImplementedException();
        }
    }
}
