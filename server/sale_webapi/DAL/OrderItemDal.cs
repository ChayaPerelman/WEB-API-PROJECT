using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using sale_webapi.Models;
using server.Models;
using System.Data;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Configuration.UserSecrets;
using sale_webapi.Models;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using sale_webapi.Models.DTO;
using Microsoft.OpenApi.Any;
using Google.Protobuf.WellKnownTypes;

namespace sale_webapi.DAL
{
    public class OrderItemDal:IOrderItemDal
    {
        private readonly OrdersContext _orderContext;
        private readonly IMapper _mapper;
  

        //private readonly AuthenticationMiddleware _authenticationMiddleware;
        //private readonly User userClaims;

        public OrderItemDal(OrdersContext orderContext, IMapper mapper)
        {
            this._orderContext = orderContext;
            this._mapper = mapper;
            //this._authenticationMiddleware = authenticationMiddleware;

        }
        public async Task<bool> AddCartAsync(int userId, ObjectToConnectDTO objectToConnectDTO)
        {
            
            var order = await _orderContext.Order.FirstOrDefaultAsync(o => o.UserId ==  userId);
            var other = new OrderItem();
            OrderItemDTO _orderItemDTO = new OrderItemDTO();
            _orderItemDTO.OrderId = order.OrderId;
            _orderItemDTO.GiftId = objectToConnectDTO.GiftId;
            _orderItemDTO.Qty = objectToConnectDTO.Qty;
            _orderItemDTO.image = objectToConnectDTO.image;
            

            OrderItem _orderItem = _mapper.Map<OrderItem>(_orderItemDTO);
            //Order _order =await _orderContext.Order.FirstOrDefaultAsync(o=>o.UserId == userId);
            if(_orderItem!=null)
            {
               other = await _orderContext.OrderItem.FirstOrDefaultAsync(oi => oi.GiftId == _orderItemDTO.GiftId);
            }

            if (other == null)
            {

                await _orderContext.OrderItem.AddAsync(_orderItem);
                _orderContext.SaveChangesAsync();
                return true;


            }
            else
            {
                other.Qty = other.Qty + _orderItem.Qty;
                _orderItem.Qty = other.Qty;
                _orderItem.image = objectToConnectDTO.image;
                _orderContext.OrderItem.Update(other);
                await _orderContext.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<List<OrderItem>> GetCartAsync(int userId)
        {
          
            var order = await _orderContext.Order.FirstOrDefaultAsync(o => o.UserId == userId);
            var user = await _orderContext.User.FirstOrDefaultAsync(o => o.UserId == userId);
            string name = user.UserFirstName+user.UserLastName; ;
            List<OrderItem> list = await _orderContext.OrderItem.Where(oi => oi.OrderId == order.OrderId).ToListAsync();
            List<OrderItemDTO2> _orderitemdto2DTO = _mapper.Map<List<OrderItemDTO2>>(list);


            //l.Add(list[0]) = list;
           
            return list;
        }

        public async Task<ToName> GetName(int userId)
        {
            var order =await _orderContext.Order.FirstOrDefaultAsync(o => o.UserId == userId);

            var user = await _orderContext.User.FirstOrDefaultAsync(o => o.UserId == userId);

            ToName name=new ToName();
            name.Name= user.UserFirstName +"  "+ user.UserLastName; ;
            name.Count = order.OrderItems.Count();



            //l.Add(list[0]) = list;

            return name;
        }


        public async Task<bool> RemoveFromCartAsync(int id)
        {
            
            var orderItemToDelete = await _orderContext.OrderItem.FirstOrDefaultAsync(oi => oi.Id == id);
            var order = await _orderContext.Order.FirstOrDefaultAsync(o =>o.OrderId == orderItemToDelete.OrderId);
                    _orderContext.OrderItem.Remove(orderItemToDelete);
                    _orderContext.SaveChanges();
                    return true;

            

        }
        public async Task<double> Creating_a_report()
        {

            List<OrderItem> orderItems = await _orderContext.OrderItem.ToListAsync();
            var count=0.0;
            foreach (var item in orderItems)
            {
                Gift gift = await _orderContext.Gift.FirstOrDefaultAsync(g => g.GiftId == item.GiftId);
                count += gift.Cost * item.Qty;
            }
            return count;

        }

        
    }

}




