using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace server.Models
{
    public class Winner
    {
        [Key, NotNull]
        public int WinnerId { get; set; }

        public int GiftId { get; set; }
        public Gift Gift { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RaffleDate { get; set; }

    }
}
