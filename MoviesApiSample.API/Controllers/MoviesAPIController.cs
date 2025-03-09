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
        private readonly MoviesApiSampleRepository _moviesApiSampleRepository;

        public MoviesAPIController(ILogger<MoviesAPIController> logger, MoviesApiSampleRepository moviesApiSampleRepository)
        {
            _logger = logger;
            _moviesApiSampleRepository = moviesApiSampleRepository;
        }

        [HttpGet(Name = "GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _moviesApiSampleRepository.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _moviesApiSampleRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost(Name = "CreateMovie")]
        public async Task<IActionResult> CreateMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }

            await _moviesApiSampleRepository.InsertMovieAsync(movie);
            return CreatedAtRoute("GetMovieById", new { id = movie.Id }, movie);
        }

        [HttpPut("{id}", Name = "UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (movie == null || movie.Id != id)
            {
                return BadRequest();
            }

            var existingMovie = await _moviesApiSampleRepository.GetMovieByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _moviesApiSampleRepository.EditMovieAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _moviesApiSampleRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _moviesApiSampleRepository.DeleteMovieAsync(movie);
            return NoContent();
        }
    }
}
