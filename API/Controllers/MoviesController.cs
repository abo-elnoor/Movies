using Application.Movies;
using Domain.Caching;
using Domain.Entities.Movies;
using Domain.Searching;
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
        private readonly ISearchManager _SearchManager;

        public MoviesController(ICacheManager cacheManager, IMovieService movieService, ISearchManager SearchManager)
        {
            this._cacheManager = cacheManager;
            this._movieService = movieService;
            this._SearchManager = SearchManager;
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

        [Route("CreateIndex")]
        [HttpGet]
        public ActionResult CreateIndex()
        {
            _SearchManager.CreateIndex<CustomMovie>("Movie");
            return Ok();
        }

        [Route("AddDocument")]
        [HttpGet]
        public ActionResult AddDocument()
        {
            try
            {
                var movies = this._movieService.GetAllMovies();
                foreach (var movie in movies)
                {
                    _SearchManager.AddDocument<CustomMovie>(movie);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [Route("Search")]
        [HttpGet]
        public ActionResult Search()
        {
            try
            {
                return Ok(_SearchManager.Search<CustomMovie>("M"));
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

    }
}
