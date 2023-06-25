using GraphQLClient.BlazorWebAssemblyFileUpload;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;
using System.Text;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services
    .AddCryptoClient()
    .ConfigureHttpClient(
        c =>    
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes("abc:abc"));
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", token);
            c.BaseAddress = new Uri("https://api-crypto-workshop.chillicream.com/graphql");
        });

await builder.Build().RunAsync();
