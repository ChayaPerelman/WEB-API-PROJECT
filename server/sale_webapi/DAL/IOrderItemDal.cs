using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.DAL
{
    public interface IOrderItemDal
    {
        Task<List<OrderItem>> GetCartAsync(int userId);
        Task<bool> AddCartAsync(int userId, ObjectToConnectDTO objectToConnectDTO);
        Task<bool> RemoveFromCartAsync(int id);
        Task<double> Creating_a_report();
        Task<ToName> GetName(int userId);
    }
}
