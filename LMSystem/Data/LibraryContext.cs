using LMSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Book> Books13 { get; set; }
        public DbSet<BorrowRecord> BorrowRecords13 { get; set; }
        public DbSet<Publication> Publications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Book>().ToTable("Books13");
            modelBuilder.Entity<BorrowRecord>().ToTable("BorrowRecords13");
            modelBuilder.Entity<Publication>().ToTable("Publications");
        }
    }
}
