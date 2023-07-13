using Domain.Entities;
using Domain.Entities.Casts;
using Domain.Entities.Movies;
using Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SqliteDbContext : DbContext, IDbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options) { }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Cast> Cast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }

}
