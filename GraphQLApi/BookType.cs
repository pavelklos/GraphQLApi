namespace GraphQLApi;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        //descriptor.Field(book => book.AuthorId).IsProjected(); // true = default
        //descriptor.Field(book => book.AuthorId).IsProjected(false);
        descriptor.Field(book => book.AuthorId);
    }
}
