using EsseEuJaLi.Server.Models;

namespace EsseEuJaLi.Server.Data
{
	public static class BookStore
	{
		public static Book[] Books = new Book[]
		{
			new Book("000", "O Hobbit", "J.R.R. Tolkien", "Fantasia", 150),
			new Book("001", "Senhor dos Aneis", "J.R.R. Tolkien", "Fantasia", 1062),
			new Book("002", "Wheel of Time", "Robert Jordan", "Fantasia", 840),
			new Book("003", "Cronicas de Nárnia", "C.S. Lewis", "Fantasia", 450),
			new Book("004", "The Witcher", "Andrzej Sapkowski", "Fantasia", 612),
			new Book("005", "Ilíada", "Homero", "Classico", 220),
			new Book("006", "Odisseia", "Homero", "Classico", 250),
            new Book("007", "Eneida", "Virgilio", "Classico", 310),
			new Book("008", "A Divina Comédia", "Dante Alighieri", "Classico", 410),
			new Book("009", "Romeu e Julieta", "William Shakespeare", "Classico", 385),
			new Book("010", "Paraíso Perdido", "John Milton", "Classico", 214)


        };
    }
}
