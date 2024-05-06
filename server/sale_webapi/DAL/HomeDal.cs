using AutoMapper;
using sale_webapi.Models;
using server.Models;
using System.Drawing;

namespace sale_webapi.DAL
{
    public class HomeDal : IHomeDal
    {
        private readonly OrdersContext _orderContext;
        private readonly IMapper _mapper;

        public HomeDal(OrdersContext orderContext, IMapper mapper)
        {
            this._orderContext = orderContext;
            this._mapper = mapper;

        }

        public async Task<List<Gift>> GetAllGiftsAsync()
        {
            return await _orderContext.Gift.ToListAsync();
        }
        public async Task<bool> AddToCartAsync(Gift gift)
        {
            
            //Gift _gift = _mapper.Map<Gift>(OrderItem);

            //orderItem= await _orderContext.Gift.



            OrderItem orderitem = _mapper.Map<OrderItem>(gift);
            
            await _orderContext.OrderItem.AddAsync(orderitem);
            _orderContext.SaveChanges();
            return true;
        }
    }
}
