using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace sale_webapi.DAL
{
    public class OrderDal : IOrderDal
    {
        private readonly OrdersContext _orderContext;
        private readonly IMapper _mapper;

        public OrderDal(OrdersContext orderContext, IMapper mapper)
        {
            this._orderContext = orderContext;
            this._mapper = mapper;

        }

        public async Task<bool> addNewOrderAsync(int userId)
        {
            User user = await _orderContext.User.FirstOrDefaultAsync(u => u.UserId == userId);

            Order neworder = new Order();

           
            neworder.User = user;
            neworder.Date = DateTime.Now;
            neworder.IsDraft = true;
            neworder.Sum = 0;
            neworder.OrderItems = null;
           

            await _orderContext.Order.AddAsync(neworder);
            _orderContext.SaveChanges();
            return true;
        }



        //public async Task<int> AddCartAsync(Order order)
        //{
        //    try
        //    {
        //        var o = await _orderContext.Order.AddAsync(order);
        //        await _orderContext.SaveChangesAsync();
        //        return o.Entity.OrderId;
        //    }
        //    catch
        //    {
        //        return -2;

        //    }
        //}

        //רק בשביל ההגרלה
        //public async Task<int> AddCartAsync(Order order)
        //{
        //    var o = await _orderContext.Order.AddAsync(order);
        //            await _orderContext.SaveChangesAsync();
        //            return o.Entity.OrderId;
        //}


        public Task<List<Gift>> GetAllGiftsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrderAsync()
        {
            
            return await _orderContext.Order.Where(o => o.IsDraft == true).ToListAsync();

        }

        public async Task<List<Order>> GetOrderByGiftAsync(string giftName)
        {
           
            List<Order> orders = await _orderContext.Order
              .Where(o => o.OrderItems.All(oi => oi.Gift.Name == giftName ))
              .Where(o=>o.IsDraft == true)
              .ToListAsync();
            return orders;
        }

        public async Task<List<AppUserDTO>> GetPurchasersAsync()
        {

            List<User> purchasers = await _orderContext.Order
                .Include(o => o.User)
                .Where(o=>o.IsDraft == true)
                .Select(u => u.User)
                .ToListAsync(); 
            List<AppUserDTO> appUserDTO = _mapper.Map<List<AppUserDTO>>(purchasers);    
            return appUserDTO;
        }

        public async Task<int> payAsync(int orderId)
        {
            var order = await _orderContext.Order.FirstOrDefaultAsync(o => o.OrderId == orderId);
            int id = order.UserId;
            //User user = (User)HttpContext.Request.HttpContext.Items["User"];
            List<Order> orders = await _orderContext.Order.Where(o => o.UserId == id).ToListAsync();
            orders.Count();
            if(orders != null)
            {
                foreach (Order item in orders)
                {
                    item.IsDraft = false;
                    _orderContext.Order.Update(item);
                    await _orderContext.SaveChangesAsync();
                
         
                //User _user = await _orderContext.User.FirstOrDefaultAsync(u => u.UserId == order.UserId);
                //UserLogin userDTO = _mapper.Map<UserLogin>(_user);

                //UserDto
                
                }
                await addNewOrderAsync(orders[0].UserId);
                return orders[0].OrderId;
            }
            
           
            return -1;
        }

        public Task<List<Order>> SearchPurchaserGiftsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
