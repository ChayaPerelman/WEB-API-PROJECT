//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System.Security.Cryptography;
//using System.Text;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using Microsoft.EntityFrameworkCore;

//using System.Drawing;
//using sale_webapi.BLL;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using sale_webapi.Models.DTO;

//namespace sale_webapi.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]


//    public class AccountController : ControllerBase
//    {
//        private readonly IAccountService _accountService;
//        private readonly ITokenService _tokenService;
//        private readonly IOrderService _orderService;

//        public AccountController(IAccountService accountservice, ITokenService tokenService, IOrderService orderService)
//        {
//            this._accountService = accountservice;
//           this. _tokenService = tokenService;
//            this._orderService = orderService;

//        }

//        [HttpPost]
//        [Route("register")]

//        public async Task<ActionResult<bool>> Register(RegisterDto registerDto)
//        {
//            var res = await _accountService.AddUser(registerDto);
//            //Console.WriteLine(res.ToString()+ "  res.ToString-register");
//            //if (res.ToString().Contains("Token"))
//            //Console.WriteLine(res);
//            if (res.Value.Username== null)
//            {
//                return BadRequest(" Duplicate user ");
//            }
//            else
//            {
//                var userToAddOrder = res.Value;
//                await _orderService.addNewOrder(userToAddOrder);
//                return new JsonResult("register success 1") { StatusCode = 200 };



//            }
        
           
//        }



//        //private async Task<bool> UserExists(string username)
//        //{
//        //    return await _accountService.UserExist(username);
//        //}



//        [HttpPost]
//        [Route("Login")]

//        public async Task<ActionResult<bool>> Login(LoginDto loginDto)
//        {
//            var res = await _accountService.AddUser2(loginDto);
//            //Console.WriteLine(res.Value.Token.ToString());
//            //Console.WriteLine(res.ToString());

//            if (res.Value.Token != null)
//            {
                
//                return new JsonResult(res.Value.Token.ToString());
//            }
                
                
//            return new JsonResult("user Not Found, go to register") { StatusCode = 400};


//        }
//        //[HttpPost]
//        //[Route("addNewOrder")]
//        //public async Task<bool> addNewOrder()
//        //{
//        //    await _orderService.addNewOrder();
//        //    return true;
//        //}
//    }
//}


