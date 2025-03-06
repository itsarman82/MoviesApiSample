using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApiSample.DAL.Framework;
using MoviesApiSample.Models;
using MoviesApiSample.Models.MovieNamespace;

namespace MoviesApiSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesAPIController : ControllerBase
    {
        private readonly ILogger<MoviesAPIController> _logger;
        private readonly MoviesApiSampleDbContex _moviesApiSampleDbContex;

        public MoviesAPIController(ILogger<MoviesAPIController> logger, MoviesApiSampleDbContex moviesApiSampleDbContex)
        {
            _logger = logger;
            _moviesApiSampleDbContex = moviesApiSampleDbContex;
        }

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movie> Get()
        {
            return _moviesApiSampleDbContex.Movies.Include(c => c.Actors).ToList();
        }
    }
}
