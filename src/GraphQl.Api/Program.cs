using GraphQl.Api;
using GraphQl.Api.Queries;
using GraphQl.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string Carriers = "carriers";
const string Fleet = "fleet";

builder.Services.AddHttpClient<CarrierService>(c => c.BaseAddress = new Uri("http://localhost:5034"));
builder.Services.AddHttpClient<FleetService>(c => c.BaseAddress = new Uri("http://localhost:5251"));

builder.Services
    .AddGraphQLServer()
    // .AddRemoteSchema(Carriers, ignoreRootTypes: true)
    // .AddRemoteSchema(Fleet, ignoreRootTypes: true)
    //.AddTypeExtensionsFromString("type Query { }")
    //.AddTypeExtensionsFromFile("./Stitching.graphql");
    .AddQueryType<Query>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();

