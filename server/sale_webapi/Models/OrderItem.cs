using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace server.Models;

public class OrderItem
{//סל 
    [Key]
    [NotNull]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int GiftId { get; set; }
    public Gift Gift { get; set; }
    public int Qty { get; set; }
    [AllowNull]
    public string image { get; set; }

}