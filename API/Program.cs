using Application.Movies;
using Domain.Caching;
using Domain.Data;
using Domain.Entities.Movies;
using Domain.Searching;
using Elasticsearch.Net;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Nest;
using static System.Reflection.Metadata.BlobBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 

builder.Services.AddControllers();

//builder.Services.AddDbContext<MovieDbContext>(m => m.UseSqlServer(builder.Configuration.GetConnectionString("MovieDB")), ServiceLifetime.Singleton);

builder.Services.AddDbContext<SqliteDbContext>(m => m.UseSqlite(builder.Configuration.GetConnectionString("MovieDatabase")), ServiceLifetime.Singleton);
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = builder.Configuration["RedisCacheUrl"]; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(Domain.Data.IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IDbContext, SqliteDbContext>();
builder.Services.AddScoped<ICacheManager, RedisCacheManager>();
builder.Services.AddScoped<IMovieService, MovieService>();

//Password for the elastic user (reset with `bin/elasticsearch-reset-password -u elastic`):
//  +92Jy5EAqf6PzI3VGcBW

//Γä╣∩╕Å  HTTP CA certificate SHA-256 fingerprint:
//  04eacab119b252a02c014b9cb49ddc1d7e840066e77b9505ba55e223966cbe06

//var settings = new ConnectionSettings(new Uri(baseUrl ?? ""))
//.PrettyJson().CertificateFingerprint("6b6a8c2ad2bc7b291a7363f7bb96a120b8de326914980c868c1c0bc6b3dc41fd")
//.BasicAuthentication("elastic", "JbNb_unwrJy3W0OaZ07n").DefaultIndex(index);

builder.Services.AddScoped<ISearchManager, Elastic_Search>();

var pool = new SingleNodeConnectionPool(new Uri(builder.Configuration["ElasticSettings:baseUrl"]));
var settings = new ConnectionSettings(pool).PrettyJson().CertificateFingerprint("04eacab119b252a02c014b9cb49ddc1d7e840066e77b9505ba55e223966cbe06")
    .BasicAuthentication("elastic", "+92Jy5EAqf6PzI3VGcBW").DefaultIndex("movies");
settings.DefaultMappingFor<CustomMovie>(m => m);
    
var client = new ElasticClient(settings);
builder.Services.AddSingleton<IElasticClient>(client);
client.Indices.Create("movies", index => index.Map<CustomMovie>(x => x.AutoMap()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



