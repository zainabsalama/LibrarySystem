using LibrarySystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.APIs.DAL;

public class SystemContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Member> Members => Set<Member>();

    public DbSet<Borrowing> Borrows => Set<Borrowing>();

    public SystemContext(DbContextOptions<SystemContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seeding Books

        modelBuilder.Entity<Book>().HasData(new List<Book>
        {
            new Book { Id = 1, Code = 1001, Title = "The Great Gatsby", NumOfCopies = 5 },
            new Book { Id = 2, Code = 2002, Title = "To Kill a Mockingbird", NumOfCopies = 10 },
            new Book { Id = 3, Code = 3003, Title = "1984", NumOfCopies = 30 },
            new Book { Id = 4, Code = 4004, Title = "Pride and Prejudice", NumOfCopies = 20 },
            new Book { Id = 5, Code = 5005, Title = "The Catcher in the Rye", NumOfCopies = 8 },
            new Book { Id = 6, Code = 6006, Title = "Moby-Dick", NumOfCopies = 14 },
            new Book { Id = 7, Code = 7007, Title = "To the Lighthouse", NumOfCopies = 16 },
            new Book { Id = 8, Code = 8008, Title = "The Lord of the Rings", NumOfCopies = 17 },
            new Book { Id = 9, Code = 9009, Title = "Harry Potter and the Sorcerer's Stone", NumOfCopies = 12 },
            new Book { Id = 10, Code = 10010, Title = "The Odyssey", NumOfCopies = 9 }
        });

        #endregion

        #region Seeding Members

        modelBuilder.Entity<Member>().HasData(new List<Member>
        {
            new Member { Id = 1, Code = 1001, Name = "John Doe" },
            new Member { Id = 2, Code = 2002, Name = "Jane Smith" },
            new Member { Id = 3, Code = 3003, Name = "Michael Johnson" },
            new Member { Id = 4, Code = 4004, Name = "Emily Brown" },
            new Member { Id = 5, Code = 5005, Name = "David Wilson" }
        });

        #endregion

        #region Seeding Borrowings

        modelBuilder.Entity<Borrowing>().HasData(
         new List<Borrowing>
         {
             new Borrowing
             {
                 BorrowingId = 1,
                 NumberOfCopies = 2,
                 IsRetrieved = false,
                 BorrowingDate = DateTime.Now,
                 RetrievalDate = null,
                 BookId = 1,
                 MemberId = 1,
             },
             new Borrowing
             {
                 BorrowingId = 2,
                 NumberOfCopies = 4,
                 IsRetrieved = false,
                 BorrowingDate = DateTime.Now.AddDays(-5),
                 RetrievalDate = null,
                 BookId = 3,
                 MemberId = 2,
             }
         });

        #endregion
    }
}
