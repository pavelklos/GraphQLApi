using GraphQLApi;

// *****************************************************************************
var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************

builder.Services.AddSingleton<BookService>();
//builder.Services.AddScoped<BookService>();
//builder.Services.AddTransient<BookService>();

// GraphQL
builder.Services.AddGraphQLServer()
    .AddMutationConventions()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .RegisterService<BookService>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

// *****************************************************************************
var app = builder.Build();
// *****************************************************************************

// GraphQL
app.MapGraphQL();

// Minimal API
app.MapGet("/", () => "Hello World!");

// *****************************************************************************
app.Run();
// *****************************************************************************
