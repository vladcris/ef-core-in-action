using ef_core_data.Models;
using Microsoft.EntityFrameworkCore;


namespace ef_core_data;
public class AppDbContext : DbContext
{
    private readonly Guid _userId;
    public AppDbContext(DbContextOptions<AppDbContext> opt, IUserIdService userIdService = null!) : base(opt)
    { 
        _userId = userIdService?.GetUserId() ?? new ReplacementUserIdService().GetUserId();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<PriceOffer> PriceOffers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book_Author>().HasKey(x => new{x.BookId, x.AuthorId});

        modelBuilder.Entity<Tag>().HasKey(x => new { x.TagId });

        modelBuilder.Entity<LineItem>()
            .HasOne(x => x.ChosenBook)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Book>().HasQueryFilter(b => !b.SoftDeleted);

        modelBuilder.Entity<Order>().HasQueryFilter(x => x.CustomerId == _userId);

        //modelBuilder.Entity<Book_Author>()
        //    .HasOne(x => x.Book)
        //    .WithMany(y => y.AuthorsLink)
        //    .HasForeignKey(x => x.BookId)
        //    .IsRequired().OnDelete(DeleteBehavior.Cascade);
        //modelBuilder.Entity<Book_Author>()
        //    .HasOne(x => x.Author)
        //    .WithMany(y => y.BookLink)
        //    .HasForeignKey(z => z.AuthorId)
        //    .IsRequired().OnDelete(DeleteBehavior.Cascade);                   
    }
}
