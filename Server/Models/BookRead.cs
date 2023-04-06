namespace EsseEuJaLi.Server.Models;

public class BookRead
{
    public BookRead(ApplicationUser user, Book book)
    {
        Book = book;
        BookId = book.Id;
        User = user;
        UserId = user.Id;
    }

    public BookRead() { }

    public Book Book { get; set; }
	public string BookId { get; set; }
	public ApplicationUser User { get; set; }
	public string UserId { get; set; }
}
