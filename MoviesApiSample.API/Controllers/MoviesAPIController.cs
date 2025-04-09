using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApiSample.DAL.Framework;
using MoviesApiSample.Models;
using MoviesApiSample.Models.ActorNamespace;
using MoviesApiSample.Models.DirectorNamespace;
using MoviesApiSample.Models.MovieNamespace;
using System.ComponentModel.DataAnnotations;

namespace MoviesApiSample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesAPIController : ControllerBase
    {
        private readonly ILogger<MoviesAPIController> _logger;
        private readonly IMoviesApiSampleRepository _moviesApiSampleRepository;

        public MoviesAPIController(ILogger<MoviesAPIController> logger, IMoviesApiSampleRepository moviesApiSampleRepository, MoviesApiSampleDbContex context)
        {
            _logger = logger;
            _moviesApiSampleRepository = moviesApiSampleRepository;
        }

        [HttpGet(Name = "GetMovies")]
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                var movies = await _moviesApiSampleRepository.GetAllMoviesAsync();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting movies.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await _moviesApiSampleRepository.GetMovieByIdAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting movie by id.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody, Required] MovieCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var movie = new Movie
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    DirectorMovie = new DirectorMovie
                    {
                        DirectorId = dto.DirectorId
                    },
                    ActorMovie = new ActorMovie
                    {
                        Actors = dto.ActorIds.Select(id => new Actor
                        {
                            Id = id
                        }).ToList()
                    }
                };

                await _moviesApiSampleRepository.InsertMovieAsync(movie);
                return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating movie.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}", Name = "UpdateMovie")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody, Required] MovieUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dto == null || dto.Id != id)
            {
                return BadRequest();
            }

            try
            {
                var existingMovie = await _moviesApiSampleRepository.GetMovieByIdAsync(id);
                if (existingMovie == null)
                {
                    return NotFound();
                }

                existingMovie.Title = dto.Title;
                existingMovie.Description = dto.Description;
                existingMovie.DirectorMovie.DirectorId = dto.DirectorId;
                existingMovie.ActorMovie.Actors = dto.ActorIds.Select(id => new Actor { Id = id }).ToList();

                await _moviesApiSampleRepository.EditMovieAsync(existingMovie);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating movie.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}", Name = "DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                var movie = await _moviesApiSampleRepository.GetMovieByIdAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }

                await _moviesApiSampleRepository.DeleteMovieAsync(movie);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting movie.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
