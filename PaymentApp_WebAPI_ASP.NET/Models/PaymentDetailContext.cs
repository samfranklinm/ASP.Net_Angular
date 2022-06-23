using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class PaymentDetailContext:DbContext
    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options) // takes in a DB provider such as SQL and takes in a DB Connection string
        {
            
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
