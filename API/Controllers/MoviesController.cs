using Application.Movies;
using Domain.Caching;
using Domain.Entities.Movies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ICacheManager _cacheManager;
        private readonly IMovieService _movieService;

        public MoviesController(ICacheManager cacheManager, IMovieService movieService)
        {
            this._cacheManager = cacheManager;
            this._movieService = movieService;
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_cacheManager.Get(string.Format(MovieService.Movie_KEY, 1), () => this._movieService.GetAllMovies()));
        }

        [Route("DataFromCache")]
        [HttpGet]
        public ActionResult DataFromCache()
        {
            return Ok(_cacheManager.Get<IList<CustomMovie>>(string.Format(MovieService.Movie_KEY, 1)));
        }

    }
}
