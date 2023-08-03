using Application.Movies;
using Domain.Caching;
using Domain.Data;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 

builder.Services.AddControllers();

//builder.Services.AddDbContext<MovieDbContext>(m => m.UseSqlServer(builder.Configuration.GetConnectionString("MovieDB")), ServiceLifetime.Singleton);

builder.Services.AddDbContext<SqliteDbContext>(m => m.UseSqlite(builder.Configuration.GetConnectionString("MovieDatabase")), ServiceLifetime.Singleton);
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = builder.Configuration["RedisCacheUrl"]; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IDbContext, SqliteDbContext>();
builder.Services.AddScoped<ICacheManager, RedisCacheManager>();
builder.Services.AddScoped<IMovieService, MovieService>();
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



