using sale_webapi.DAL;
using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public class OrderItemService: IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;
        public OrderItemService(IOrderItemDal orderItemDal)
        {
            this._orderItemDal = orderItemDal;
        }

        public async Task<bool> AddToCart(int userId, ObjectToConnectDTO objectToConnectDTO)
        {
            return await _orderItemDal.AddCartAsync( userId,objectToConnectDTO);
        }

        public async Task<List<OrderItem>> GetCart(int userId)
        {
            return await _orderItemDal.GetCartAsync(userId);
        }

        public async Task<ToName> GetName(int userId)
        {
            return await _orderItemDal.GetName(userId);
        }

        public async Task<bool> RemoveFromCart(int id)
        {
            return await _orderItemDal.RemoveFromCartAsync(id);
        }
        
        public async Task<double> Creating_a_report()
        {
            return await _orderItemDal.Creating_a_report();
        }
    }
}
