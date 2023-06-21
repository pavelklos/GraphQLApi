// [Get started with Strawberry Shake in Console application] TUTORIAL
// - https://chillicream.com/docs/strawberryshake/v13/get-started/console
// - FILE 'ConferenceClient.Client.cs' GENERATED
// - IN FOLDER '\obj\Debug\net8.0\berry'

using GraphQLClient.Console.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
    .AddConferenceClient()
    .ConfigureHttpClient(client =>
        client.BaseAddress = new Uri("https://workshop.chillicream.com/graphql"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

IConferenceClient client = services.GetRequiredService<IConferenceClient>();

var result = await client.GetSessions.ExecuteAsync();
result.EnsureNoErrors();

foreach (var session in result.Data.Sessions.Nodes)
{
    Console.WriteLine(session.Title);
}