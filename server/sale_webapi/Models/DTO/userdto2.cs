using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace sale_webapi.Models.DTO
{
    public class userdto2
    {
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

        
    }
}
