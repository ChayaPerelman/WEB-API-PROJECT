using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sale_webapi.BLL;
using sale_webapi.Models.DTO;
using server.Models;
using System.Data;
using System.Drawing;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sale_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;


        public OrderItemController(IOrderItemService orderItemservice,  IMapper mapper)
        {
            this._orderItemService = orderItemservice;
           // this._tokenService = tokenService;
            this._mapper = mapper;

        }

        [HttpGet]
        [Route("GetCart")]
        [Authorize(Roles = "user")]
        public async Task<List<OrderItemDTO>> GetCart()
        {
            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];
                var l = await _orderItemService.GetCart(user.UserId);

                List<OrderItemDTO> _orderitemdto2DTO = _mapper.Map<List<OrderItemDTO>>(l);

                return _orderitemdto2DTO;
            }

            catch (Exception ex)
            {

                throw ex;
            }

         
        }
        [HttpGet]
        [Route("GetName")]
        public async  Task<ToName> GetName()
        {
            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];
                var name = await _orderItemService.GetName(user.UserId);
                return name;
            }

            catch (Exception ex)
            {

                throw ex;
            }
         

        }



        //public async Task<IEnumerable<OrderItem>> Get(string giftName)
        //{
        //    var middlewareUser = HttpContext.Items["User"] as User;
        //    if (middlewareUser == null)
        //    {
        //        return null;
        //    }
        //    return await _orderservice.GetGiftCards(giftName);
        //}

        [HttpPost]
        [Route("addToCart")]
        [Authorize (Roles ="user")]
        public async Task<bool> AddToCart(ObjectToConnectDTO objectToConnectDTO)
        //, string token)
        {
            try
            {
                User user = (User)HttpContext.Request.HttpContext.Items["User"];
                //if (ModelState.IsValid)
                // if (_orderItem.Order.IsDraft == null)
                //     return false;
                //if ( _orderItem.Order.IsDraft==false )
                // {
                var res = await _orderItemService.AddToCart(user.UserId, objectToConnectDTO);
                if (res)
                    return true;
                else
                    return false;
            }

            catch (Exception ex)
            {

                throw ex;
            }

   

            //}
            //return false;
        }

        [HttpDelete]
        [Route("RemoveFromCart")]
        public async Task<bool> RemoveFromCart(int id)
        {
            try
            {
                var middlewareUser = HttpContext.Items["User"] as User;
                //if (middlewareUser == null)
                //{
                //    return false;
                //}

                return await _orderItemService.RemoveFromCart(id);
            }

            catch (Exception ex)
            {

                throw ex;
            }

          
        }
        [HttpPost]
        [Route("Creating_a_report")]

        public async Task<double> Creating_a_report()
        

        {
            try
            {
                return await _orderItemService.Creating_a_report();

            }

            catch (Exception ex)
            {

                throw ex;
            }

          
        }

        //[HttpGet("GetCart")]
        //public async Task<ActionResult<List<OrderItem>>> GetCart()
        //{
        //    var user = User.Claims.FirstOrDefault(c => c.Type == "userId");
        //    int.TryParse(user?.Value, out int userId);
        //    //return await _orderItemService.GetCartAsync(userId);
        //    return null;
        //}
    }
}
 

