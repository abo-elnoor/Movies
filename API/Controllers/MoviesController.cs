using Application.Movies;
using Domain.Entities.Movies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<IList<CustomMovie>> Get()
        {
            return Ok(this._movieService.GetAllMovies());
        }

    }
}
