namespace GraphQLApi;

public class BookService
{
    public BookService()
    {
        //Books = new List<Book> {
        //    new("C# in Depth", new Author("Jon Skeet")),
        //    new("C# in Depth - 2nd Edition", new Author("Jon Skeet")),
        //    new("C# in Depth - 3rd Edition", new Author("Jon Skeet")),
        //};
    }

    public ICollection<Book> Books { get; } = new List<Book>();
}

//public record Book(string Title, Author Author);

//public record Author(string Name);
