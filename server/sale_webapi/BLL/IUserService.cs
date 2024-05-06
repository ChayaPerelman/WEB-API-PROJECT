using sale_webapi.Models;
using sale_webapi.Models.DTO;
using server.Models;

namespace sale_webapi.BLL
{
    public interface IUserService
    {
        public Task<bool> AddUser(userdto2 user);
        public List<string> Generate(User user);
        public Task<User> Authenticate(UserDto userdto);
    }
}
