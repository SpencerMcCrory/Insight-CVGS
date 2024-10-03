
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
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A6029E9857");

            entity.Property(e => e.AccountBlocked).HasDefaultValue(false);
        });

        modelBuilder.Entity<AddressTable>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__AddressT__091C2AFB39A9FCFC");

            entity.Property(e => e.City).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.DelivaryInstructions).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IsShipping).HasDefaultValue(false);
            entity.Property(e => e.MemberId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PostalCode).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Province).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Unit).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Member).WithMany(p => p.AddressTables).HasConstraintName("FK__AddressTa__Membe__37A5467C");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11AC26BB96");

            entity.HasOne(d => d.Account).WithOne(p => p.Employee).HasConstraintName("FK__Employee__Accoun__4AB81AF0");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EvTypeId).HasName("PK__EventTyp__AB03639D23DD2E7D");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Friend__3213E83FF8C767A3");

            entity.HasOne(d => d.FriendNavigation).WithMany(p => p.FriendFriendNavigations).HasConstraintName("FK__Friend__FriendId__01142BA1");

            entity.HasOne(d => d.Member).WithMany(p => p.FriendMembers).HasConstraintName("FK__Friend__MemberId__00200768");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Game__2AB897FDFDD7A2F9");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PhysicalAvailable).HasDefaultValue(false);
            entity.Property(e => e.Price).HasDefaultValue(0.0);
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__GameCate__19093A0B9B437C98");
        });

        modelBuilder.Entity<GameDetailsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameDeta__3213E83FF75E4E2C");

            entity.HasOne(d => d.Category).WithMany(p => p.GameDetailsCategories).HasConstraintName("FK__GameDetai__Categ__6E01572D");

            entity.HasOne(d => d.Game).WithMany(p => p.GameDetailsCategories).HasConstraintName("FK__GameDetai__GameI__6D0D32F4");
        });

        modelBuilder.Entity<GameDetailsLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameDeta__3213E83F73E5CFA0");

            entity.HasOne(d => d.Game).WithMany(p => p.GameDetailsLanguages).HasConstraintName("FK__GameDetai__GameI__74AE54BC");

            entity.HasOne(d => d.Language).WithMany(p => p.GameDetailsLanguages).HasConstraintName("FK__GameDetai__Langu__75A278F5");
        });

        modelBuilder.Entity<GameDetailsPlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameDeta__3213E83F0DF49720");

            entity.HasOne(d => d.Game).WithMany(p => p.GameDetailsPlatforms).HasConstraintName("FK__GameDetai__GameI__70DDC3D8");

            entity.HasOne(d => d.Platform).WithMany(p => p.GameDetailsPlatforms).HasConstraintName("FK__GameDetai__Platf__71D1E811");
        });

        modelBuilder.Entity<GameEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__GameEven__7944C810B391920B");

            entity.Property(e => e.AddressId).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EndDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EventLink).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Address).WithMany(p => p.GameEvents).HasConstraintName("FK__GameEvent__Addre__46E78A0C");

            entity.HasOne(d => d.EvType).WithMany(p => p.GameEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GameEvent__EvTyp__45F365D3");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(e => e.PlatformId).HasName("PK__GamePlat__F559F6FA12C9DA8F");
        });

        modelBuilder.Entity<LanguageTable>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855ABFE91B4BF");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B184382EC6A");

            entity.Property(e => e.Dob).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Gender).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.RecievesEmails).HasDefaultValue(true);

            entity.HasOne(d => d.Account).WithOne(p => p.Member).HasConstraintName("FK__Member__AccountI__2E1BDC42");
        });

        modelBuilder.Entity<MemberEventRegist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberEv__3213E83F25D92871");

            entity.HasOne(d => d.Event).WithMany(p => p.MemberEventRegists).HasConstraintName("FK__MemberEve__Event__7D439ABD");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberEventRegists).HasConstraintName("FK__MemberEve__Membe__7C4F7684");
        });

        modelBuilder.Entity<MemberGameCategoryPref>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberGa__3213E83F24BAB782");

            entity.HasOne(d => d.Category).WithMany(p => p.MemberGameCategoryPrefs).HasConstraintName("FK__MemberGam__Categ__66603565");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberGameCategoryPrefs).HasConstraintName("FK__MemberGam__Membe__656C112C");
        });

        modelBuilder.Entity<MemberLanguagePref>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberLa__3213E83FDC7C2908");

            entity.HasOne(d => d.Language).WithMany(p => p.MemberLanguagePrefs).HasConstraintName("FK__MemberLan__Langu__6A30C649");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberLanguagePrefs).HasConstraintName("FK__MemberLan__Membe__693CA210");
        });

        modelBuilder.Entity<MemberPlatformPref>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MemberPl__3213E83F889AE61D");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberPlatformPrefs).HasConstraintName("FK__MemberPla__Membe__619B8048");

            entity.HasOne(d => d.Platform).WithMany(p => p.MemberPlatformPrefs).HasConstraintName("FK__MemberPla__Platf__628FA481");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3213E83F8DE83A7D");

            entity.Property(e => e.IsShipped).HasDefaultValue(false);

            entity.HasOne(d => d.Game).WithMany(p => p.OrderItems).HasConstraintName("FK__OrderItem__GameI__5EBF139D");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasConstraintName("FK__OrderItem__Order__5DCAEF64");
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderTab__C3905BCFB966C68E");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OrderFulfilled).HasDefaultValue(true);
            entity.Property(e => e.OrderTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Member).WithMany(p => p.OrderTables)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderTabl__Membe__59FA5E80");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__74BC79CE5A4B41B3");

            entity.HasOne(d => d.Game).WithMany(p => p.Reviews).HasConstraintName("FK__Review__GameId__52593CB8");

            entity.HasOne(d => d.Member).WithMany(p => p.Reviews).HasConstraintName("FK__Review__MemberId__5441852A");

            entity.HasOne(d => d.Status).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__StatusId__534D60F1");
        });

        modelBuilder.Entity<ReviewStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ReviewSt__C8EE206307A035F5");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WishList__3213E83F32F00C6C");

            entity.HasOne(d => d.Game).WithMany(p => p.WishLists).HasConstraintName("FK__WishList__GameId__797309D9");

            entity.HasOne(d => d.Member).WithMany(p => p.WishLists).HasConstraintName("FK__WishList__Member__787EE5A0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
