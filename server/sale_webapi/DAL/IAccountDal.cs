using Microsoft.AspNetCore.Mvc;
using sale_webapi.Models;
using sale_webapi.Models.DTO;

namespace sale_webapi.DAL
{
    public interface IAccountDal
    {
        Task<ActionResult<UserDto>> Register(RegisterDto registerDto);
        Task<ActionResult<UserDto>> Login(LoginDto loginDto);
        Task<bool> UserExists(string username);
    }
}
