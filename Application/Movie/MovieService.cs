using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities.Cast;
using Domain.Entities.Movies;
using Infrastructure.Casts;
using Infrastructure.Movies;
using Infrastructure.Persons;

namespace Application.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _MovieRepository;
        private readonly ICastRepository _CastRepository;
        private readonly IPersonRepository _PersonRepository;

        public MovieService(IMovieRepository MovieRepository,
            ICastRepository CastRepository, IPersonRepository PersonRepository)
        {
            this._MovieRepository = MovieRepository;
            this._CastRepository = CastRepository;
            this._PersonRepository = PersonRepository;
        }
        void IMovieService.DeleteMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }

        IList<CustomMovie> IMovieService.GetAllMovies()
        {
            var movies = from m in _MovieRepository.Table
                         join p1 in _PersonRepository.Table on m.DirectorId equals p1.Id
                         select new CustomMovie
                         {
                             MovieId = m.Id,
                             MovieTitle = m.Title,
                             DirectorName = p1.Name,
                             DirectorGender = p1.Gender
                         };
            movies = movies.ToList();

            foreach (var item in movies)
            {
                var casts = from c in _CastRepository.Table
                            join m in _MovieRepository.Table on c.MovieId equals m.Id
                            join p in _PersonRepository.Table on c.PersonId equals p.Id
                            where c.MovieId == item.MovieId
                            select new CustomMovieCast
                            {
                                CastId = c.Id,
                                CastName = p.Name,
                                CharName = c.CharName,
                                CastGender = p.Gender,
                                CharGender = c.CharGender,
                                CastOrder = c.CastOrder
                            };

                item.Casts = casts.ToList();
            }

            return movies.ToList();
        }

        Movie IMovieService.GetMovieById(int MovieId)
        {
            throw new NotImplementedException();
        }

        void IMovieService.InsertMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }

        void IMovieService.UpdateMovie(Movie Movie)
        {
            throw new NotImplementedException();
        }
    }
}
