namespace EsseEuJaLi.Shared;

public class BookDto
{
	public BookDto(string id, string title, string author, string genre, int pages)
	{
		Id = id;
		Title = title;
		Author = author;
		Genre = genre;
		Pages = pages;
	}

	public string Id { get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
	public int Pages { get; set; }
}
