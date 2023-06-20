namespace GraphQLApi;

public class Query
{
    public Book GetBook() =>
        new("C# in Depth", new Author("Jon Skeet"));

    public IEnumerable<Book> GetBooks()
    {
        yield return new("C# in Depth", new Author("Jon Skeet"));
        yield return new("C# in Depth - 2nd Edition", new Author("Jon Skeet"));
        yield return new("C# in Depth - 3rd Edition", new Author("Jon Skeet"));
    }
}

public record Book(string Title, Author Author);

public record Author(string Name);
