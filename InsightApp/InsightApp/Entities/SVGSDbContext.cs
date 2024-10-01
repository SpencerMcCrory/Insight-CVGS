
using InsightApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

public partial class SVGSDbContext : DbContext
{
    public SVGSDbContext()
    {
    }

    public SVGSDbContext(DbContextOptions<SVGSDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AddressTable> AddressTables { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<GameDetailsCategory> GameDetailsCategories { get; set; }

    public virtual DbSet<GameDetailsLanguage> GameDetailsLanguages { get; set; }

    public virtual DbSet<GameDetailsPlatform> GameDetailsPlatforms { get; set; }

    public virtual DbSet<GameEvent> GameEvents { get; set; }

    public virtual DbSet<GamePlatform> GamePlatforms { get; set; }

    public virtual DbSet<LanguageTable> LanguageTables { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberEventRegist> MemberEventRegists { get; set; }

    public virtual DbSet<MemberGameCategoryPref> MemberGameCategoryPrefs { get; set; }

    public virtual DbSet<MemberLanguagePref> MemberLanguagePrefs { get; set; }

    public virtual DbSet<MemberPlatformPref> MemberPlatformPrefs { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderTable> OrderTables { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewStatus> ReviewStatuses { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=SVGSContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A6C7AAAD02");

            entity.Property(e => e.AccountBlocked).HasDefaultValue(false);
        });

        modelBuilder.Entity<AddressTable>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__AddressT__091C2AFBF3982758");

            entity.Property(e => e.City).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DelivaryInstructions).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IsShipping).HasDefaultValue(false);
            entity.Property(e => e.PostalCode).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Province).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Unit).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Member).WithMany(p => p.AddressTables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AddressTa__Membe__36B12243");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11158344BC");

            entity.HasOne(d => d.Account).WithOne(p => p.Employee).HasConstraintName("FK__Employee__Accoun__49C3F6B7");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EvTypeId).HasName("PK__EventTyp__AB03639DEDE24A02");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasOne(d => d.FriendNavigation).WithMany().HasConstraintName("FK__Friend__FriendId__76969D2E");

            entity.HasOne(d => d.Member).WithMany().HasConstraintName("FK__Friend__MemberId__75A278F5");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game__2AB897FD9BB30888");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PhysicalAvailable).HasDefaultValue(false);
            entity.Property(e => e.Price).HasDefaultValue(0.0);
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__GameCate__19093A0BE50035F0");
        });

        modelBuilder.Entity<GameDetailsCategory>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany().HasConstraintName("FK__GameDetai__Categ__68487DD7");

            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK__GameDetai__GameI__6754599E");
        });

        modelBuilder.Entity<GameDetailsLanguage>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK__GameDetai__GameI__6D0D32F4");

            entity.HasOne(d => d.Language).WithMany().HasConstraintName("FK__GameDetai__Langu__6E01572D");
        });

        modelBuilder.Entity<GameDetailsPlatform>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK__GameDetai__GameI__6A30C649");

            entity.HasOne(d => d.Platform).WithMany().HasConstraintName("FK__GameDetai__Platf__6B24EA82");
        });

        modelBuilder.Entity<GameEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__GameEven__7944C810AF78C465");

            entity.Property(e => e.AddressId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EndDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EventLink).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Address).WithMany(p => p.GameEvents).HasConstraintName("FK__GameEvent__Addre__45F365D3");

            entity.HasOne(d => d.EvType).WithMany(p => p.GameEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameEvent__EvTyp__44FF419A");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(e => e.PlatformId).HasName("PK__GamePlat__F559F6FAEA2217D5");
        });

        modelBuilder.Entity<LanguageTable>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855AB2AE2749A");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B187D4F50D7");

            entity.Property(e => e.Dob).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Gender).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RecievesEmails).HasDefaultValue(true);

            entity.HasOne(d => d.Account).WithOne(p => p.Member).HasConstraintName("FK__Member__AccountI__2E1BDC42");
        });

        modelBuilder.Entity<MemberEventRegist>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany().HasConstraintName("FK__MemberEve__Event__73BA3083");

            entity.HasOne(d => d.Member).WithMany().HasConstraintName("FK__MemberEve__Membe__72C60C4A");
        });

        modelBuilder.Entity<MemberGameCategoryPref>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany().HasConstraintName("FK__MemberGam__Categ__628FA481");

            entity.HasOne(d => d.Member).WithMany().HasConstraintName("FK__MemberGam__Membe__619B8048");
        });

        modelBuilder.Entity<MemberLanguagePref>(entity =>
        {
            entity.HasOne(d => d.Language).WithMany().HasConstraintName("FK__MemberLan__Langu__656C112C");

            entity.HasOne(d => d.Member).WithMany().HasConstraintName("FK__MemberLan__Membe__6477ECF3");
        });

        modelBuilder.Entity<MemberPlatformPref>(entity =>
        {
            entity.HasOne(d => d.Member).WithMany().HasConstraintName("FK__MemberPla__Membe__5EBF139D");

            entity.HasOne(d => d.Platform).WithMany().HasConstraintName("FK__MemberPla__Platf__5FB337D6");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.IsShipped).HasDefaultValue(false);

            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK__OrderItem__GameI__5CD6CB2B");

            entity.HasOne(d => d.Order).WithMany().HasConstraintName("FK__OrderItem__Order__5BE2A6F2");
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderTab__C3905BCF0A2B2331");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OrderFulfilled).HasDefaultValue(true);
            entity.Property(e => e.OrderTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Member).WithMany(p => p.OrderTables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderTabl__Membe__59063A47");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79CEC6399325");

            entity.HasOne(d => d.Game).WithMany(p => p.Reviews).HasConstraintName("FK__Review__GameId__5165187F");

            entity.HasOne(d => d.Member).WithMany(p => p.Reviews).HasConstraintName("FK__Review__MemberId__534D60F1");

            entity.HasOne(d => d.Status).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__StatusId__52593CB8");
        });

        modelBuilder.Entity<ReviewStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ReviewSt__C8EE2063B9498C2B");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany().HasConstraintName("FK__WishList__GameId__70DDC3D8");

            entity.HasOne(d => d.Member).WithMany().HasConstraintName("FK__WishList__Member__6FE99F9F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
