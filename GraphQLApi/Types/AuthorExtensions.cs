namespace GraphQLApi.Types;

using Path = System.IO.Path;

[ExtendObjectType(typeof(Author))]
public class AuthorExtensions
{
    public Uri? GetProfilePicture([Parent] Author author)
    {
        if (File.Exists(Path.Combine(Constants.ImageDirectory, $"{author.Id}.png")))
        {
            return new Uri($"{Constants.ImageRoot}/{author.Id}.png");
        }
        return null;
    }
}