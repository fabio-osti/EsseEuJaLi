using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EsseEuJaLi.Server.Models;

public class ApplicationUser : IdentityUser
{
	public List<BookRead> BooksRead { get; set; } = new();
	public int GetPoints()
	{
		int points = 0;
		foreach (var book in BooksRead) {
			points += 1 + book.Book.Pages / 100;
		}
		return points;
	}
	public string[] GetTrophies()
	{
		var grouped = BooksRead
			.GroupBy(e => e.Book.Genre);
		var selected = grouped
			.Select(e => new {
				Genre = e.Key,
				Count = e.Where(b => b.Book.Genre == e.Key).Count()
			});

        return selected
			.Where(e => e.Count >= 5)
			.Select(e => $"Leitor de {e.Genre}")
			.ToArray();
    }
}
