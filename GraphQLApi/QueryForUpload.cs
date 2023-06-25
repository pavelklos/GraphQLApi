// How to implement GraphQL file upload with Hot Chocolate
// - https://www.youtube.com/watch?v=XeF3IuGDq4A
// GraphQL multipart request specification
// - https://github.com/jaydenseric/graphql-multipart-request-spec

namespace GraphQLApi;

using Path = System.IO.Path;

public class QueryFU
{
    public BookFU GetBook()
        => new BookFU("C# in depth.", new AuthorFU(1, "Jon Skeet"));
}

public class MutationFU
{
    public async Task<AuthorFU> UploadProfilePicture(int authorId, IFile file, CancellationToken cancellationToken)
    {
        using var stream = File.Create(Path.Combine(Constants.ImageDirectory, $"{authorId}.png"));
        await file.CopyToAsync(stream, cancellationToken);
        return new AuthorFU(authorId, "Jon Skeet");
    }
}

public record BookFU(string Title, AuthorFU Author);

public record AuthorFU(int Id, string Name);
