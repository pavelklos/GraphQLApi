using HotChocolate.Data.Sorting;

namespace GraphQLApi;

public class BookSortType : SortInputType<Book>
{
    protected override void Configure(ISortInputTypeDescriptor<Book> descriptor)
    {
        //descriptor.Field(book => book.Title).Ignore();
        descriptor.Field(book => book.Title).Type<BookTitleSortEnumType>();
    }
}
