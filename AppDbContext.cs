using dbLogServices.Models;
using Microsoft.EntityFrameworkCore;

namespace dbLogServices
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<RCHALLAN> RCHALLANs { get; set; }
        public virtual DbSet<ICHALLAN> ICHALLANs { get; set; }
        public virtual DbSet<CUSTOMERMST> CUSTOMERMSTs { get; set; }
        public virtual DbSet<ShopList> ShopLists { get; set; }



    }
}
