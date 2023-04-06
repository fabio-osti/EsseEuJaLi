using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using EsseEuJaLi.Server.Models;

namespace EsseEuJaLi.Server.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public void Seed()
    {
        if (Books.Count() != BookStore.Books.Length) {
            Books.RemoveRange(Books);
            Books.AddRange(BookStore.Books);
            SaveChanges();
        }
    }
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    public DbSet<BookRead> BooksRead { get; set; }
    public DbSet<Book> Books { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
        builder.Entity<Book>().HasKey(e => e.Id);
        builder.Entity<BookRead>().HasKey(e => new { e.UserId, e.BookId });
        builder.Entity<BookRead>()
            .HasOne(e => e.User)
            .WithMany(e => e.BooksRead)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
        builder.Entity<BookRead>()
            .HasOne(e => e.Book)
            .WithMany(e => e.BooksRead)
            .HasForeignKey(e => e.BookId)
            .IsRequired();
	}
}
