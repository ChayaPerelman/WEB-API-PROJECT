using server.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace sale_webapi.Models.DTO
{
    public class OrderItemDTO2
    {

        [Key]
        [NotNull]
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int GiftId { get; set; }
     
        public int Qty { get; set; }
        public string Name { get; set; }

    }
}
