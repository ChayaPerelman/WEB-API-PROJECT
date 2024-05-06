
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//using System.Security.Cryptography;
//using System.Text;
//using sale_webapi.BLL;

//using sale_webapi.DAL;
//using server.Models;
//using sale_webapi.BLL;
//using Microsoft.AspNetCore.Http;
//using sale_webapi.Models.DTO;
//using sale_webapi.Models;

//namespace sale_webapi.DAL
//{
//    public class AccountDal:IAccountDal
//    //:IAccountDal
//    {
//        private readonly OrdersContext _context;
//        private readonly ITokenService _tokenService;
        
//        private bool flag;

//        public AccountDal(OrdersContext context,ITokenService tokenService)
//        {
//            _context = context;
//            this._tokenService = tokenService;
//        }


//        //public class CookieOAuthBearerProvider : OAuthBearerAuthenticationProvider
//        //{
//        //    public override Task RequestToken(OAuthRequestTokenContext context)
//        //    {
//        //        base.RequestToken(context);
//        //        var value = context.Request.Cookies["AuthToken"];
//        //        if (!string.IsNullOrEmpty(value))
//        //        {
//        //            context.Token = value;
//        //        }
//        //        return Task.FromResult<object>(null);
//        //    }
//        //}
//        public async Task<ActionResult<UserLogin>> Register(RegisterDto registerDto)
//        {
//            if (!await UserExists(registerDto.Username))
//            {

//                var hmac = new HMACSHA512();

//                var user = new User
//                {
//                    UserName = registerDto.Username.ToLower(),
//                    FirstName = registerDto.FirstName,
//                    LastName = registerDto.LastName,
//                    Email = registerDto.Email,
//                    Role = EnumRoleUser.custumer,
//                   PhonNumber= registerDto.PhonNumber,
//                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
//                    PasswordSalt = hmac.Key,

//                };
//                _context.AppUser.Add(user);
//                await _context.SaveChangesAsync();

             

               


//                flag = true;


//                return new UserLogin
//                {
//                    Username = user.UserName,
//                    Token = _tokenService.CreateToken(user)
//                };
                
//            }
//            flag = false;
//            return new UserLogin
//            {
               
//            };
           
//        }
//        public async Task<bool> UserExists(string username)
//        {
//            bool res = await _context.AppUser.AnyAsync(x => x.UserName == username.ToLower());
//            return res;
//        }
//        public async Task <ActionResult<UserLogin>> Login(LoginDto loginDto)
//        {
  
//            var user = await _context.AppUser
//                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
//            await _context.SaveChangesAsync();

//                if (user != null) { 
//                var hmac = new HMACSHA512(user.PasswordSalt);

//            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

//            for (int i = 0; i < computedHash.Length; i++)
//            {
//                    if (computedHash[i] != user.PasswordHash[i])
//                        return null;
//            }

//              var x= new UserLogin
//                {
//                    Username = user.UserName,
//                 Token = _tokenService.CreateToken(user)

//            };
//                return x;
//            }

//                return new UserLogin
//                { };
//        }
//    }
//}
