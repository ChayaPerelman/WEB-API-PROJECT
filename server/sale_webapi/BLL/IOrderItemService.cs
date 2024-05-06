using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetCart(int userId);
        Task<bool> AddToCart(int userId, ObjectToConnectDTO objectToConnectDTO);
        Task<bool> RemoveFromCart(int id);
        Task<double> Creating_a_report();
        Task<ToName> GetName(int userId);
    }
}
