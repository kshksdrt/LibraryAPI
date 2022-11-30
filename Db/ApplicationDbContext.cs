using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseMySQL("server=localhost;database=library;user=root;password=root");
    optionsBuilder.EnableDetailedErrors();
  }

  public DbSet<Book> Books { get; set; }
  public DbSet<Author> Authors { get; set; }

  #region Required
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Author>();
    modelBuilder.Entity<Author>().Property(b => b.Name).IsRequired();
    modelBuilder.Entity<Book>();
    modelBuilder.Entity<Book>().Property(b => b.Name).IsRequired();
  }
  #endregion
}
