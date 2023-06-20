using HotChocolate.Data.Filters;

namespace GraphQLApi;

public class BookFilterType : FilterInputType<Book>
{
    protected override void Configure(IFilterInputTypeDescriptor<Book> descriptor)
    {
        //descriptor.Field(book => book.Title).Ignore();
        descriptor.Field(book => book.Title).Type<BookTitleOperationFilterInputType>();
    }
}
