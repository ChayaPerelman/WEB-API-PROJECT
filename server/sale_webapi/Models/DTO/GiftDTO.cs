using server.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sale_webapi.Models.DTO
{
    public class GiftDTO
    {
        public int GiftId { get; set; }
        public string Name { get; set; }

        [NotNull]
        public int DonorId { get; set; }


        [NotNull]
        public EnumGiftCategory Category { get; set; }

        public double Cost { get; set; }

        public string Image { get; set; }
    }
}
