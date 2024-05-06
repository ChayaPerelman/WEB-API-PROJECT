using sale_webapi.BLL;
using sale_webapi.DAL;
using sale_webapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using sale_webapi.BLL;
using sale_webapi.Models;
using server.Models;
using sale_webapi.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sale_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly OrdersContext _ordersContext;

        private readonly IConfiguration _config;
        private readonly IOrderService _orderService;
        private readonly IUserService _user;

        public UserController(IConfiguration config, OrdersContext ordersContext, IUserService user, IOrderService orderService)
        {
            _orderService = orderService;
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _ordersContext = ordersContext ?? throw new ArgumentNullException(nameof(ordersContext));
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        //[AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register([FromBody] userdto2 user)
        {
            if ( user.UserPassword == null || user.UserEmail == null || 

               user.UserId == null || user.UserPhone == null || user.UserName == null || user.UserLastName == null

                || user.UserFirstName == null )
            {

                return NotFound("Details are missing");

            }
            else
            {
                
                var registered = await _user.AddUser(user);
                _ordersContext.SaveChanges();
                User user1 = await _ordersContext.User.FirstOrDefaultAsync(u => u.UserLastName == user.UserLastName);
                
                await _orderService.addNewOrder(user1.UserId);
                return Ok(registered);
            }

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<List<OrderItem>>> Login([FromBody] UserDto userLogin)
        {
            var user = await _user.Authenticate(userLogin);

            if (user != null)
            {
                var tokenAndStatus = _user.Generate(user);
                var token = tokenAndStatus[0];
                var status = tokenAndStatus[1];
                return Ok(new { token, status });
                //return Ok(token);
            }
            return NotFound("User not found");
        }



    }
}
