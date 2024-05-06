
using sale_webapi.Models;
using server.Models;

namespace sale_webapi.BLL
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
