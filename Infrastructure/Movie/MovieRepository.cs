using Domain.Data;
using Domain.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Movies
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> lstMovies = new List<Movie>()
        {
           new Movie{  Id =1 ,Title= "Movie1", DirectorId=1 },
           new Movie{  Id =2 ,Title= "Movie2", DirectorId=2 }
        };

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Movie GetById(object id)
        {
            return lstMovies.Where(m=>m.Id==(int)id).FirstOrDefault();
        }

        public Movie Insert(Movie entity)
        {
            throw new NotImplementedException();
        }

        public IList<Movie> Table
        {
            get
            {
                return lstMovies;
            }            
        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
