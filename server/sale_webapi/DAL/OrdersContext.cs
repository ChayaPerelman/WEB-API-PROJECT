
using sale_webapi.Models;
using server.Models;

namespace sale_webapi.DAL
{
    public class OrdersContext: DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext>options): base(options)
        {

        }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Gift> Gift { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Winner> Winner { get; set; }
       


    }

    
}
