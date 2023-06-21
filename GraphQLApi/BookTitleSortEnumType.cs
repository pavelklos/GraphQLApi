using HotChocolate.Data.Sorting;

namespace GraphQLApi;

public class BookTitleSortEnumType : DefaultSortEnumType
{
    protected override void Configure(ISortEnumTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultSortOperations.Ascending);
    }
}
