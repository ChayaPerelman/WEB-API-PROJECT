using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.DAL
{
    public interface IUserDal
    {
        Task<bool> AddUserDal(userdto2 user);
        public Task<User> AuthenticateDal(UserDto userLogin);

    }
}
