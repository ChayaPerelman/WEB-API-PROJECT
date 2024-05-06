using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace server.Models;

public class User
{
    internal static readonly object Claims;

    // public int Id { get; set; }
    // public string UserName { get; set; }

    // public byte[] PasswordHash { get; set; }
    // public byte[] PasswordSalt { get; set; }

    // [NotNull]
    // [MaxLength(50)]
    // public string FirstName { get; set; }

    // [NotNull]
    // [MaxLength(50)]
    // public string LastName { get; set; }
    // [MaxLength(15)]
    // public string PhonNumber { get; set; }

    // public string Email { get; set; }
    // public EnumRoleUser Role { get; set; }//מנהל משתמש
    //public  ICollection<Order> Orders { get; set; }



    [Key]
    public int UserId { get; set; }

    public string UserName { get; set; }

    [PasswordPropertyText]
    public string UserPassword { get; set; }

    [StringLength(30)]
    public string UserFirstName { get; set; }
    [StringLength(30)]
    public string UserLastName { get; set; }

    [Phone]
    public string UserPhone { get; set; }
    [EmailAddress]
    public string UserEmail { get; set; }

    public EnumRoleUser role { get; set; }
    public ICollection<Order> Orders { get; set; }
}




