using sale_webapi.DAL;
using sale_webapi.Models;
using sale_webapi.Models;
using Microsoft.IdentityModel.Tokens;
using sale_webapi.BLL;
using sale_webapi.DAL;
using sale_webapi.Models;
using server.Models;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using sale_webapi.Models.DTO;

namespace sale_webapi.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IConfiguration _config;
        public UserService(IUserDal userDal, IConfiguration config)
        {
            this._userDal = userDal;
            this._config = config;

        }

        public async Task<bool> AddUser(userdto2 user)
        {
            return await _userDal.AddUserDal(user);
        }

        //public User ValidateToken(string token)
        //{
        //    // Split the token to get the username and expiry date
        //    string[] tokenParts = token.Split(':');

        //    if (tokenParts.Length == 2)
        //    {
        //        string username = tokenParts[0];
        //        string expiryDateString = tokenParts[1];

        //        // Validate the expiry date
        //        if (DateTime.TryParse(expiryDateString, out DateTime expiryDate))
        //        {
        //            // Check if the token is still valid
        //            if (expiryDate > DateTime.Now)
        //            {
        //                // Create and return a new User object

        //                User user = new User();
        //                user.UserName = username;
        //                return user;
        //            }
        //        }
        //    }

        //    // In case the token is invalid or expired, return null or throw an exception
        //    return null;
        //}

        public List<string> Generate(User user)
        {
            var status = "user";
            if (user.role == EnumRoleUser.admin)
                status = "manager";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserFirstName),
                new Claim(ClaimTypes.NameIdentifier,user.UserLastName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.HomePhone,user.UserPhone),
         
                new Claim(ClaimTypes.Email,user.UserEmail),
          
                new Claim(ClaimTypes.Role,status),
                new Claim("userId",user.UserId.ToString())
            }; 

            var token = new JwtSecurityToken(
                issuer: "http://localhost:4200/",
                audience: "http://localhost:4200/",
                claims,        
                expires: DateTime.Now.AddMinutes(15),        
                signingCredentials: credentials);
            var a = new List<string>();
            a.Add(new JwtSecurityTokenHandler().WriteToken(token));
            a.Add(status);
            return a;

        }

        public async Task<User> Authenticate(UserDto userLogin)
        {
            return await _userDal.AuthenticateDal(userLogin);
        }
    }

}

