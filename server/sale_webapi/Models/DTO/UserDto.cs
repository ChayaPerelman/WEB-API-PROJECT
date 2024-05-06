using System.ComponentModel;

namespace sale_webapi.Models.DTO;

public class UserDto
{
    public string UserName { get; set; }

    [PasswordPropertyText]
    public string UserPassword { get; set; }
}
