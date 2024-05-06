using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace server.Models
{
    public class Order
    {
        [Key]
        [NotNull]
        public int OrderId { get; set; }
            public ICollection<OrderItem> OrderItems { get; set; }//מיצג את הסל שלי
            public int UserId { get; set; }
            public User User { get; set; }
            public DateTime Date { get; set; }
            public int Sum { get; set; }

            [DefaultValue (true)]
            public bool IsDraft { get; set; }
    }
}







