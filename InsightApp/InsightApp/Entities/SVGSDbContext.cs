using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities
{
    public class SVGSDbContext : DbContext
    {
        public SVGSDbContext(DbContextOptions<SVGSDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

    }
}
