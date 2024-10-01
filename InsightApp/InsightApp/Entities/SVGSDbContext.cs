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
        public DbSet<AddressTable> Addresses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<GameDetailsCategory> GameDetailsCategories { get; set; }
        public DbSet<GameDetailsLanguage> GameDetailsLanguages { get; set; }
        public DbSet<GameDetailsPlatform> GameDetailsPlatforms { get; set; }
        public DbSet<GameEvent> GameEvents { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<LanguageTable> Languages { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberEventRegist> MemberEventRegists { get; set; }
        public DbSet<MemberGameCategoryPref> MemberGameCategoryPrefs { get; set; }
        public DbSet<MemberLanguagePref> MemberLanguagePrefs { get; set; }
        public DbSet<MemberPlatformPref> MemberPlatformPrefs { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderTable> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewStatus> ReviewStatuses { get; set; }
        public DbSet<WishList> WishLists { get; set; }

    }
}
