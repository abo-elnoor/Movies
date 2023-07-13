using Domain.Entities.Casts;
using Domain.Entities.Movies;
using Domain.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Movie>().HasData(
                    new Movie() { Id = 1, Title = "Movie1", DirectorId = 1 },
                    new Movie() { Id = 2, Title = "Movie2", DirectorId = 2 });

            modelBuilder.Entity<Person>().HasData(
              new Person() { Id = 1, Name = "Director1", Gender = 'F' },
              new Person() { Id = 2, Name = "Director2", Gender = 'M' },
              new Person() { Id = 3, Name = "Person3", Gender = 'F' },
              new Person() { Id = 4, Name = "Person4", Gender = 'M' },
              new Person() { Id = 5, Name = "Person5", Gender = 'M' },
              new Person() { Id = 6, Name = "Person6", Gender = 'F' },
              new Person() { Id = 7, Name = "Person7", Gender = 'M' },
              new Person() { Id = 8, Name = "Person8", Gender = 'M' });

            modelBuilder.Entity<Cast>().HasData(
               new Cast() { Id = 1, PersonId = 3, CharName = "Cast1", MovieId = 1, CastOrder = 1, CharGender = 'F' },
               new Cast() { Id = 2, PersonId = 4, CharName = "Cast2", MovieId = 1, CastOrder = 1, CharGender = 'M' },
               new Cast() { Id = 3, PersonId = 5, CharName = "Cast3", MovieId = 1, CastOrder = 2, CharGender = 'F' },
               new Cast() { Id = 4, PersonId = 6, CharName = "Cast4", MovieId = 2, CastOrder = 1, CharGender = 'F' },
               new Cast() { Id = 5, PersonId = 7, CharName = "Cast5", MovieId = 2, CastOrder = 2, CharGender = 'M' },
               new Cast() { Id = 6, PersonId = 8, CharName = "Cast6", MovieId = 2, CastOrder = 3, CharGender = 'M' }
               );
        }
    }
}
