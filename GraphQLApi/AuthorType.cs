namespace GraphQLApi;

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        // Add Field (get all books for Author.Id
        //descriptor.Field("booksAdded")
        //    .Resolve(context =>
        //    {
        //        var id = context.Parent<Author>().Id;

        //        return context.Service<ApplicationDbContext>().Books.Where(book => book.AuthorId == id);
        //    })
        //    .Serial()
        //    .Type<NonNullType<ListType<BookType>>>();

        // for AuthorBooksDataLoader
        descriptor.Field("books")
            .Resolve(async context =>
            {
                var key = context.Parent<Author>().Id;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<AuthorBooksDataLoader>().LoadAsync(key, cancellationToken);
            })
            //.Serial()
            .Type<NonNullType<ListType<BookType>>>();
    }
}
