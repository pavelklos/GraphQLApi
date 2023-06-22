namespace GraphQLApi;

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        //descriptor.Field(book => book.AuthorId).IsProjected(); // true = default
        //descriptor.Field(book => book.AuthorId).IsProjected(false);

        // Ignore Field
        // - The field `authorId` does not exist on the type `Book`.
        //descriptor.Field(book => book.AuthorId).Ignore();

        // Add Field
        //descriptor.Field("authorAdded")
        //    .Resolve(async context =>
        //    {
        //        var keyValues = new object[] { context.Parent<Book>().AuthorId };
        //        var cancellationToken = context.RequestAborted;

        //        return await context.Service<ApplicationDbContext>().Authors.FindAsync(keyValues, cancellationToken);
        //    })
        //    .Serial()
        //    //.Parallel()
        //    .Type<NonNullType<AuthorType>>();

        // Replace Field
        //descriptor.Field(book => book.AuthorId)
        //    .Name("authorReplaced")
        //    .Resolve(async context =>
        //    {
        //        var keyValues = new object[] { context.Parent<Book>().AuthorId };
        //        var cancellationToken = context.RequestAborted;

        //        return await context.Service<ApplicationDbContext>().Authors.FindAsync(keyValues, cancellationToken);
        //    })
        //    .Serial()
        //    .Type<NonNullType<AuthorType>>();

        // for AuthorDataLoader
        descriptor.Field(book => book.AuthorId)
            .Name("author")
            .Resolve(async context =>
            {
                var key = context.Parent<Book>().AuthorId;
                var cancellationToken = context.RequestAborted;

                return await context.DataLoader<AuthorDataLoader>().LoadAsync(key, cancellationToken);
            })
            //.Serial()
            .Type<NonNullType<AuthorType>>();
    }
}
