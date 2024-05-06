using server.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sale_webapi.Models.DTO
{
    public class DonorDTO
    {
        [NotNull]
        public string FirstName { get; set; }
        [NotNull]

        public string LastName { get; set; }
        [MaxLength(15)]

        public string PhonNumber { get; set; }

        public string Email { get; set; }
    }
}
