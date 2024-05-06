using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sale_webapi.Models.DTO;

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }

    [NotNull]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [NotNull]
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(15)]
    public string PhonNumber { get; set; }

    public string Email { get; set; }



    //עדיף לא לשים סיסמא
}
