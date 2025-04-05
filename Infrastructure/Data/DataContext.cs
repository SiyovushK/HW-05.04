using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.ISBN)
            .IsUnique();

        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .HasMaxLength(200)
            .IsRequired();

        modelBuilder.Entity<Book>()
            .Property(b => b.ISBN)
            .HasMaxLength(13)
            .IsRequired();

        modelBuilder.Entity<Book>()
            .Property(b => b.Description)
            .HasMaxLength(1000);

        modelBuilder.Entity<Book>()
            .HasCheckConstraint("CK_Book_Year", "\"Year\" BETWEEN 1450 AND 2100")
            .HasCheckConstraint("CK_Book_Pages", "\"Pages\" BETWEEN 1 AND 10000");

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(b => b.GenreId);


        modelBuilder.Entity<Author>()
            .Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Author>()
            .Property(a => a.Country)
            .HasMaxLength(100);

        modelBuilder.Entity<Author>()
            .Property(a => a.Biography)
            .HasMaxLength(1000);

        modelBuilder.Entity<Author>()
            .HasCheckConstraint("CK_Author_BirthYear", "\"BirthYear\" BETWEEN 1000 AND 2100");


        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.Name)
            .IsUnique();

        modelBuilder.Entity<Genre>()
            .Property(g => g.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Genre>()
            .Property(g => g.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<Genre>()
            .HasCheckConstraint("CK_Genre_Popularity", "\"Popularity\" BETWEEN 0 AND 100");
    }

}