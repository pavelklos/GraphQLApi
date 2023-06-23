using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GraphQLClient.BlazorWebAssembly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Strawberry Shake generator produced Client, but also components that we can use in Blazor
// - [CryptoClient.Client.cs] client generated in folder '\obj\Debug\net8.0\berry'
//   - we can use generated extension AddCryptoClient() on IServiceCollection
//   - add CryptoClient to dependency injection
builder.Services
    .AddCryptoClient()
    .ConfigureHttpClient(client =>
        client.BaseAddress = new Uri("https://demo.chillicream.com/graphql"));

await builder.Build().RunAsync();
