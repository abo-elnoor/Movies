using Domain.Data;
using Domain.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Movies
{
    public interface IMovieRepository : IRepository<Movie>
    {
    }
}
