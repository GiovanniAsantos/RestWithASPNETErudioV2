using RestWithASPNET10Erudio.Rest.Configuration;
using RestWithASPNET10Erudio.Rest.Repositories;
using RestWithASPNET10Erudio.Rest.Repositories.Impl;
using RestWithASPNET10Erudio.Rest.Services;
using RestWithASPNET10Erudio.Rest.Services.Impl.V1;
using RestWithASPNET10Erudio.Rest.Services.Impl.V2;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services.AddControllers().AddContentNegotiation().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new RestWithASPNET10Erudio.Rest.Utils.DateTimeConverter());
});

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddEvolve(builder.Configuration, builder.Environment);

builder.AddSerilogLogging();

// Person services and repositories
builder.Services.AddScoped<IPersonService, PersonImpl>();

// Book services 
builder.Services.AddScoped<IBookService, BookImpl>();

// Person services V2
builder.Services.AddScoped<PersonImplV2>();

// Generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepositoryImpl<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();