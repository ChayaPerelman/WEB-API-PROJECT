using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sale_webapi.BLL;
using sale_webapi.Models.DTO;
using server.Models;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sale_webapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    //Task<List<Order>> GetOrder();
    //Task<List<Order>> GetOrderByGift(Gift gift);
    //Task<List<Order>> SearchPurchaserGifts();
    //Task<List<User>> GetPurchasers();

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        IMapper _mapper;
        public OrderController(IOrderService orderservice, IMapper mapper)
        {
            this._orderservice = orderservice;
            this._mapper = mapper;

        }

        // GET: api/<OrderController>
        [HttpGet]
        [Route("GetOrder")]
        public async Task<List<Order>> GetOrder()
        {
            try
            {
                return await _orderservice.GetOrder();

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET api/<OrderController>/5
        [HttpGet]
        [Route("GetOrderByGift")]
        public async Task<List<Order>> GetOrderByGift(string giftName)
        {
            try
            {
                return await _orderservice.GetOrderByGift(giftName);

            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        //[HttpGet]
        //[Route("SearchPurchaserGifts")]
        //public async Task<List<Order>> SearchPurchaserGifts()
        //{
        //    return await _orderservice.SearchPurchaserGifts();
        //}
  


        [HttpGet]
        [Route("GetPurchasers")]
        public async Task<List<AppUserDTO>> GetPurchasers()
        {
            try
            {
                return await _orderservice.GetPurchasers();

            }

            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPost]
        [Route("pay")]
        public async Task<int> Pay(int num)
        {

            try
            {

                User user = (User)HttpContext.Request.HttpContext.Items["User"];

                return await _orderservice.pay(user.UserId);
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST api/<OrderController>
        //[HttpPost]
        //[Route("AddToCart")]
        //public async Task<int> AddToCart(OrderDTO orderDTO)
        //{
        //    var _order = _mapper.Map<Order>(orderDTO);
        //    if (ModelState.IsValid)
        //    {
        //        return await _orderservice.AddCartAsync(_order);
        //    }
        //    return -1;
        //}

        //// PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        // POST api/<GiftController>

    }
}

