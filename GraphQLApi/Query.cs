using Microsoft.EntityFrameworkCore;

namespace GraphQLApi;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Author> GetAuthors(ApplicationDbContext context)
    {
        //return context.Authors
        //    .Include(author => author.Books);
        return context.Authors;
    }

    //[UseFirstOrDefault]
    //[UseSingleOrDefault]
    [UseProjection]
    //[UseFiltering]
    [UseFiltering<BookFilterType>]
    //[UseSorting]
    [UseSorting<BookSortType>]
    public IQueryable<Book> GetBooks(ApplicationDbContext context)
    {
        //return context.Books
        //    .Include(book => book.Author);
        return context.Books;
    }

    //public Book GetBook(BookService bookService) =>
    //    bookService.Books.Last();

    //public IEnumerable<Book> GetBooks(BookService bookService) =>
    //    bookService.Books;

    //public Book GetBook() =>
    //    new("C# in Depth", new Author("Jon Skeet"));

    //public IEnumerable<Book> GetBooks()
    //{
    //    yield return new("C# in Depth", new Author("Jon Skeet"));
    //    yield return new("C# in Depth - 2nd Edition", new Author("Jon Skeet"));
    //    yield return new("C# in Depth - 3rd Edition", new Author("Jon Skeet"));
    //}
}
