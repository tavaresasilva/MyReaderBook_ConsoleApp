using Microsoft.EntityFrameworkCore;
using MyReaderBook.Domain;
using Microsoft.EntityFrameworkCore.Proxies;

namespace MyReaderBook.Data
{
    public class MyReaderBookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReaderBook>(e => e.ToTable("ReaderBooks"));
            modelBuilder.Entity<ReaderBook>(e => e.HasKey( k => new { k.BookId, k.ReaderId}));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost;Database=myReadBook;Trusted_Connection=True;");

            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
