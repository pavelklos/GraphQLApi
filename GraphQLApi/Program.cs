using GraphQLApi;
using Microsoft.EntityFrameworkCore;

// *****************************************************************************
var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextOptionsBuilder) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    dbContextOptionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

// Services
builder.Services.AddSingleton<BookService>();
//builder.Services.AddScoped<BookService>();
//builder.Services.AddTransient<BookService>();

// GraphQL
builder.Services.AddGraphQLServer()
    .AddMutationConventions()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .RegisterService<BookService>()
    .RegisterDbContext<ApplicationDbContext>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

// *****************************************************************************
var app = builder.Build();
// *****************************************************************************

// GraphQL
app.MapGraphQL();

// Minimal API
app.MapGet("/", () => "Hello World!");

// DbContext
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();
}

// *****************************************************************************
app.Run();
// *****************************************************************************
