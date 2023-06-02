using LibrarySystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.APIs.DAL;

public class SystemContext:DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Member> Member=> Set<Member>();

    public DbSet<Borrowing> Borrow => Set<Borrowing>();

    public DbSet<Retrieval> Retrieval => Set<Retrieval>();

    public SystemContext(DbContextOptions<SystemContext> options):base(options)
    { }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
        
    //}
}
