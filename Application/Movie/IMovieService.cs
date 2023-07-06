using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Movies;


namespace Application.Movies
{
    public interface IMovieService
    {
        Movie GetMovieById(int MovieId);

        void DeleteMovie(Movie Movie);

        void InsertMovie(Movie Movie);

        void UpdateMovie(Movie Movie);
        IList<CustomMovie> GetAllMovies();
    }
}
